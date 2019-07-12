using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ISaveable
{
    [SerializeField] float health = 100;

    public bool IsAlive { get; private set; } = true;

    private bool isInstalled = false;//?????
    BaseStats baseStats;
    private float startHealth;

    private void Awake()
    {
        baseStats = GetComponent<BaseStats>();
        startHealth= baseStats.GetStat(Stats.Health);
        //health = GetComponent<BaseStats>().GetHealth();
        //health = startHealth;
        Debug.Log(startHealth);
    }

    private void Update()
    {
        if (!isInstalled)//????
        {
            health = GetComponent<BaseStats>().GetStat(Stats.Health);///?????
            isInstalled = true;///????
        }
    }

    public void TakeDamage(GameObject initiator, int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
            AwardXP(initiator);
        }
    }

    private void AwardXP(GameObject initiator)
    {
        Experience experience = initiator.GetComponent<Experience>();
        if (experience == null)
            return;

        experience.GainExperience(baseStats.GetStat(Stats.AwardXP));
    }

    private void Death()
    {
        if (IsAlive)
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<ActionSchedule>().CancelAllControls();
            //GetComponent<CapsuleCollider>().enabled = false;//to make arrow fly through body
            IsAlive = false;
        }
    }

    public object CaptureState()
    {
        return health;
    }

    public void RestoreState(object state)
    {
        health = (int)state;

        if(health<=0)
        {
            Death();
        }
    }

    public float GetHealth()
    {
        return 100 * (health / startHealth);
    }
}
