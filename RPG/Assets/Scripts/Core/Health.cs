using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ISaveable
{
    [SerializeField] float health = -1f;
    [SerializeField] float regeneration = 70f;

    public bool IsAlive { get; private set; } = true;

    BaseStats baseStats;

    private void Awake()
    {
        baseStats = GetComponent<BaseStats>();
        health = baseStats.GetStat(Stats.Health);
    }

    private void OnEnable()
    {
        baseStats.onLevelUp += RegenerateHealth;
    }

    private void OnDisable()
    {
        baseStats.onLevelUp -= RegenerateHealth;
    }

    public void TakeDamage(GameObject initiator, float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            Death();
            AwardXP(initiator);
        }
    }

    public float GetPercentageHealth()
    {
        return 100 * (health / baseStats.GetStat(Stats.Health));
    }

    public float GetHealth()
    {
        return health;
    }

    public float GetMaxHealth()
    {
        return baseStats.GetStat(Stats.Health);
    }

    private void AwardXP(GameObject initiator)
    {
        Experience experience = initiator.GetComponent<Experience>();
        if (experience == null)
            return;

        experience.GainExperience(baseStats.GetStat(Stats.AwardXP));
    }

    private void RegenerateHealth()
    {
        float regenHealth = baseStats.GetStat(Stats.Health) * (regeneration / 100);
        health = Mathf.Max(health, regenHealth);
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
        health = (float)state;

        if(health<=0)
        {
            Death();
        }
    }
}
