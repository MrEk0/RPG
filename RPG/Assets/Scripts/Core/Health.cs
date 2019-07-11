using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour, ISaveable
{
    [SerializeField] int health = 100;

    public bool IsAlive { get; private set; } = true;

    private bool isInstalled = false;//?????

    private void Awake()
    {
        health = GetComponent<BaseStats>().GetHealth();
        Debug.Log(health);
    }

    private void Update()
    {
        if(!isInstalled)//????
        {
            health = GetComponent<BaseStats>().GetHealth();///?????
            isInstalled = true;///????
        }

        if (health<=0)
        {
            Death();
        }
    }

    public void TakeDamage(int damage)
    {
        //health = Mathf.Max(health - damage, 0);
        //if (health>0)
        //{
            health -= damage;
            print(health);
        //}
        //else
        //{
        //    Death();
        //}
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
}
