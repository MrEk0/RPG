using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Fighter fighter;
    Mover mover;
    Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
        fighter = GetComponent<Fighter>();
        mover = GetComponent<Mover>();
    }

    void Update()
    {
        if (!health.IsAlive) return;

        if (AttackEnemy())
            return;
        if (SetCursorToMove())
            return;
    }

    private bool AttackEnemy()
    {
        RaycastHit[] hits = Physics.RaycastAll(GetRay());
        foreach (RaycastHit hit in hits)
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy == null) continue;

            if (fighter.CanAttack(enemy.gameObject))
            {
                if (Input.GetMouseButton(0))
                {
                    enemy.Attack();
                    fighter.AttackTheTarget(enemy.gameObject);
                }
                return true;
            }

        }
        return false;
    }

    private bool SetCursorToMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(GetRay(), out hit))
        {
            if (Input.GetMouseButton(0))
            {
                mover.StartMovement(hit.point, 1f);
            }
            return true;
        }
        return false;
    }

    private Ray GetRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

 }
