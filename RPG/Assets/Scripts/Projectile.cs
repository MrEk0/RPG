﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] float speed = 5f;
    [SerializeField] bool isTargeted;

    Transform prTransform;
    Health target;
    int damage;

    private void Start()
    {
        prTransform = GetComponent<Transform>();//to get rid of transform in Update;?
        prTransform.LookAt(goalForProjectile());
    }
    // Update is called once per frame
    void Update()
    {
        if (target == null)
            return;

        if (isTargeted && target.IsAlive)
        {
            prTransform.LookAt(goalForProjectile());
        }

        prTransform.Translate(Vector3.forward * speed * Time.deltaTime);
        
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if(collision.gameObject.GetComponent<Health>()==target)
    //    {
    //        if (!target.IsAlive)
    //            return;

    //        target.TakeDamage(damage);
    //        Destroy(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject, 3);
    //    }
    //}

    private void OnTriggerEnter(Collider collider)   //The second variant   !!!!TRIGGER
    {
        if (collider.GetComponent<Health>()==target)
        {
            //Debug.Log("Enemy was shot");
            if (!target.IsAlive)
                return;

            target.TakeDamage(damage);
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject, 3);
        }
    }

    public void targetInstall(Health target, int damage)
    {
        this.target = target;
        this.damage = damage;
    }

    public Vector3 goalForProjectile()
    {
        CapsuleCollider collider = target.GetComponent<CapsuleCollider>();
        if(collider!=null)
        {
            return target.transform.position + Vector3.up*collider.height / 2;
        }
        return target.transform.position;
    }
}