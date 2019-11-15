﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Fighter : MonoBehaviour, IAction, ISaveable, IModifier
{
    [SerializeField] float timeBetweenAttacks = 2f;
    [SerializeField] Transform rightHandPosition = null;
    [SerializeField] Transform leftHandPosition = null;
    [SerializeField] WeaponConfig defaultWeapon=null;
    [SerializeField] UnityEvent hitSoundEvent;
  
    Mover mover;
    Health target;
    ActionSchedule actionSchedule;
    Animator animator;
    WeaponConfig currentWeapon=null;
    BaseStats baseStats=null;
    float timeSinceLastAttack = Mathf.Infinity;

    private void Awake()
    {
        mover = GetComponent<Mover>();
        actionSchedule = GetComponent<ActionSchedule>();
        animator = GetComponent<Animator>();
        baseStats = GetComponent<BaseStats>();
    }

    // Start is called before the first frame update
    void Start()
    {
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

    public void EquipWeapon(WeaponConfig weapon)
    {
        currentWeapon = weapon;
        //currentWeapon.Spawner(rightHandPosition, leftHandPosition, animator);
        weapon.Spawner(rightHandPosition, leftHandPosition, animator);
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

        hitSoundEvent.Invoke();
        float damage = baseStats.GetStat(Stats.Damage);
        target.TakeDamage(gameObject, damage);
    }

    private void Shoot()
    {
        if (target == null)
            return;

        float damage = baseStats.GetStat(Stats.Damage);
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

    public float GetAdditiveModifier(Stats stat)
    {
        if (stat == Stats.Damage)
        {
            return currentWeapon.GetDamage();
        }
        return 0f;
    }

    public object CaptureState()
    {
        Debug.Log($"{currentWeapon.name}+{gameObject.name}");
        return currentWeapon.name;
    }

    public void RestoreState(object state)
    {
        string weaponName = (string)state;
        WeaponConfig weapon = Resources.Load<WeaponConfig>(weaponName);
        EquipWeapon(weapon);
    }

    public Health GetTarget()
    {
        return target;
    }
}
