using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{
    [SerializeField] float chaseRange = 5f;
    [SerializeField] float suspectTime = 2f;
    [SerializeField] float agroCooldownTime = 3f;
    [SerializeField] float stopTime = 3f;
    [SerializeField] float attackSpeed = 3f;
    [SerializeField] float shoutDistance = 5f;
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
    float timeSinceAggravated = Mathf.Infinity;
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

        if (IsAggravated()  && fighter.CanAttack(player))
        {
            timeSinceLastSawPlayer = 0f;
            fighter.AttackTheTarget(player);

            AggravateNearbyEnemies();
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
        timeSinceAggravated += Time.deltaTime;
    }

    public void Aggravate()
    {
        timeSinceAggravated = 0f;
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

    private bool IsAggravated()
    {
        float distance = Vector3.Distance(transform.position, player.transform.position);

        return distance < chaseRange || timeSinceAggravated < agroCooldownTime;
    }

    private void AggravateNearbyEnemies()
    {
        RaycastHit[] hits=Physics.SphereCastAll(transform.position, shoutDistance, Vector3.up, 0);
        for(int i=0; i<hits.Length; i++)
        {
            AIController controller = hits[i].transform.GetComponent<AIController>();
            if (controller == null)
                continue;

            controller.Aggravate();
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }
}
