using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Mover : MonoBehaviour, IAction, ISaveable
{
    [SerializeField] GameObject target;
    [SerializeField] float maxSpeed = 6f;
    
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
