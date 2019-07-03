using System;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Health))]
public class Enemy : MonoBehaviour
{
    public void Attack()
    {
        Debug.Log("Attack");
    }
}

