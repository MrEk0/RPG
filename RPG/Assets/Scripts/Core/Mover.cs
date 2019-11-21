using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour, IAction, ISaveable
{
    [SerializeField] GameObject target;
    [SerializeField] float maxSpeed = 6f;
    [SerializeField] float maxPathDistance = 30f;


    private NavMeshAgent navMeshAgent;
    private Animator animator;
    ActionSchedule actionSchedule;
    Health health;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
        actionSchedule = GetComponent<ActionSchedule>();
        health = GetComponent<Health>();
    }

    void Update()
    {
        navMeshAgent.enabled = health.IsAlive;

        UpdateMovements();
    }

    private void UpdateMovements()
    {
        Vector3 playerSpeed = navMeshAgent.velocity;
        Vector3 localVelocity = transform.InverseTransformDirection(playerSpeed);
        float speed = localVelocity.z;
        animator.SetFloat("Speed", speed);
    }

    public void StartMovement(Vector3 target, float speedFraction)
    {
        actionSchedule.StartAction(this);
        SetDestination(target, speedFraction);
    }

    public bool CanMoveTo(Vector3 destination)
    {
        NavMeshPath path = new NavMeshPath();//a list of waypoints stored in the corners array
        bool hasPath = NavMesh.CalculatePath(transform.position, destination, NavMesh.AllAreas, path);
        if (!hasPath)
            return false;
        if (path.status != NavMeshPathStatus.PathComplete)
            return false; // to avoid a possible movement to a "walkable" position which is not achievable
        if (GetLengthPath(path) > maxPathDistance)
            return false;

        return true;
    }

    private float GetLengthPath(NavMeshPath path)//the full distance to the target
    {
        float pathDistance = 0f;

        if (path.corners.Length < 2)
            return pathDistance;
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            pathDistance += Vector3.Distance(path.corners[i], path.corners[i + 1]);
        }
        return pathDistance;
    }

    public void SetDestination(Vector3 target, float speedFraction)
    {
        navMeshAgent.destination = target;
        navMeshAgent.speed = maxSpeed * Mathf.Clamp01(speedFraction);
        navMeshAgent.isStopped = false;
    }

    public void Cancel()
    {
        navMeshAgent.isStopped = true;
    }

    public object CaptureState()
    {
        return new Serializable(transform.position);
    }

    public void RestoreState(object state)
    {
        Serializable position = (Serializable)state;
        transform.position = position.ToVector();
        actionSchedule.CancelAllControls();
    }
}
