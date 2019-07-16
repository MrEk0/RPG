using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fighter : MonoBehaviour, IAction, ISaveable
{
    [SerializeField] float timeBetweenAttacks = 2;
    [SerializeField] Transform rightHandPosition = null;
    [SerializeField] Transform leftHandPosition = null;
    [SerializeField] Weapon defaultWeapon=null;
  
    Mover mover;
    Health target;
    ActionSchedule actionSchedule;
    Animator animator;
    Weapon currentWeapon=null;
    float timeSinceLastAttack = Mathf.Infinity;

    // Start is called before the first frame update
    void Start()
    {
        mover = GetComponent<Mover>();
        actionSchedule = GetComponent<ActionSchedule>();
        animator = GetComponent<Animator>();

        if(currentWeapon==null)
        EquipWeapon(defaultWeapon);
    }


    // Update is called once per frame
    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;

        if (target == null)
            return;

        if (GetIsInRange())
        {
            mover.SetDestination(target.transform.position, 1f);
        }
        else
        {
            mover.Cancel();
            AttackBehaviour();
        }
    }

    public void EquipWeapon(Weapon weapon)
    {
        currentWeapon = weapon;
        currentWeapon.Spawner(rightHandPosition, leftHandPosition, animator);
    }

    private void AttackBehaviour()
    {
        transform.LookAt(target.transform);
        if(timeSinceLastAttack>timeBetweenAttacks)
        {
            if (!target.IsAlive)
                return;
            TriggerBehaviour();
            timeSinceLastAttack = 0f;
        }

    }

    private void TriggerBehaviour()
    {
        animator.SetTrigger("Attack");
        animator.SetBool("stopAttack", false);

        //animator.ResetTrigger("StopAttack");
        //animator.SetTrigger("Attack");
    }

    //AnimationEvent
    private void Hit()
    {
        if (target == null)
            return;

        float damage = GetComponent<BaseStats>().GetStat(Stats.Damage);//to finish!!
        target.TakeDamage(gameObject, damage);
    }

    private void Shoot()
    {
        if (target == null)
            return;

        float damage = GetComponent<BaseStats>().GetStat(Stats.Damage);// to finish!!!
        if(currentWeapon.isHasProjectile())
        {
            currentWeapon.LaunchTheProjectile(gameObject, rightHandPosition, leftHandPosition, target, damage);
        }
        else
        {
            Hit();
        }
    }

    private bool GetIsInRange()
    {
        return Vector3.Distance(transform.position, target.transform.position) > currentWeapon.GetRange();
    }

    public void AttackTheTarget(GameObject target)
    {
        actionSchedule.StartAction(this);
        this.target = target.GetComponent<Health>();
        
    }

    public void Cancel()
    {
        //animator.SetTrigger("StopAttack");
        animator.SetBool("stopAttack", true);
        target = null;
        mover.Cancel();
    }

    public bool CanAttack(GameObject enemy)
    {
        if (enemy != null)
        {
            return enemy.GetComponent<Health>().IsAlive;
        }
        return false;
    }

    public object CaptureState()
    {
        return currentWeapon.name;
    }

    public void RestoreState(object state)
    {
        string weaponName = (string)state;
        Weapon weapon = Resources.Load<Weapon>(weaponName);
        EquipWeapon(weapon);
    }

    public Health GetTarget()
    {
        return target;
    }
}
