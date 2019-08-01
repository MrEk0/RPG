using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Template_Method
{
    abstract class Enemies
    {
        public void Create()
        {
            Attack();
            Death();
            //Fly();
            Move();
            TakeDamage();
        }

        protected abstract void Attack();
        protected abstract void Death();
        //protected virtual void Fly()
        //{
        //    Debug.Log("Flight");
        //}
        protected virtual void Move()
        {
            Debug.Log("Movement");
        }
        protected abstract void TakeDamage();
    }
}
