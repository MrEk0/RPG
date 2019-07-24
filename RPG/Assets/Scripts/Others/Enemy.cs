using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour, IRaycastable
{
    public Cursors GetCursors()
    {
        return Cursors.Attack;
    }

    public bool HandleRaycast(Player player)
    {
        if (player.GetComponent<Fighter>().CanAttack(gameObject))
        {
            if (Input.GetMouseButton(0))
            {
                player.GetComponent<Fighter>().AttackTheTarget(gameObject);
            }
            return true;
        }
        return false;
    }
}

