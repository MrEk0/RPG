using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ISaveable
{
    [SerializeField] int health = 100;

    public bool IsAlive { get; private set; } = true;

    public void TakeDamage(int damage)
    {
        //health = Mathf.Max(health - damage);
        if(health>0)
        {
            health -= damage;
            print(health);
        }
        else
        {
            Death();
        }
    }

    private void Death()
    {
        if (IsAlive)
        {
            GetComponent<Animator>().SetTrigger("Death");
            GetComponent<ActionSchedule>().CancelAllControls();
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
}
