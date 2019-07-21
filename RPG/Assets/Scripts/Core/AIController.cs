using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float suspectTime = 2f;
    [SerializeField] float stopTime = 3f;
    [SerializeField] float attackSpeed = 3f;
    [Range(0,1)]
    [SerializeField] float patrolSpeedFraction = 0.3f;
    [SerializeField] AIPath path;

    GameObject player;
    Fighter fighter;
    Health health;
    Mover mover;
    Vector3 startPosition;
    ActionSchedule actionSchedule;

    float timeSinceLastSawPlayer = Mathf.Infinity;
    int currentWayPoint = 0;
    float timeSinceStop = Mathf.Infinity;


    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        fighter = GetComponent<Fighter>();
        health = GetComponent<Health>();
        mover = GetComponent<Mover>();
        actionSchedule = GetComponent<ActionSchedule>();
    }

    private void Start()
    {
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!health.IsAlive) return;

        if (GetDisstanceToPlayer() < chaseRange && fighter.CanAttack(player))
        {
            timeSinceLastSawPlayer = 0f;
            fighter.AttackTheTarget(player);
        }
        else if (timeSinceLastSawPlayer < suspectTime) 
        {
            actionSchedule.CancelAllControls();
        }
        else
        {
            PatrolBehaviour();
        }

        timeSinceLastSawPlayer += Time.deltaTime;
        timeSinceStop += Time.deltaTime;
    }

    private void PatrolBehaviour()
    {
        fighter.Cancel();
        Vector3 nextPosition=startPosition;

        if (path != null)
        {
            if (isReachedWayPoint())
            {
                timeSinceStop = 0;
                currentWayPoint = path.GetNextChildPosition(currentWayPoint);
            }
            nextPosition = path.GetChildPosition(currentWayPoint);
        }

        if (timeSinceStop > stopTime)
        {
            mover.StartMovement(nextPosition, patrolSpeedFraction);
        }
    }

    private bool isReachedWayPoint()
    {
        float distanceToWayPoint = Vector3.Distance(transform.position, GetNextWayPoint());
        return distanceToWayPoint < 1f;
    }

    private Vector3 GetNextWayPoint()
    {
        return path.GetChildPosition(currentWayPoint);
    }

    private float GetDisstanceToPlayer()
    {
        return Vector3.Distance(transform.position, player.transform.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
