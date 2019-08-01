using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Template_Method
{
    class Ork : Enemies
    {
        protected override void Attack()
        {
            Debug.Log("Ork Attacks player");
        }

        protected override void Death()
        {
            Debug.Log("Ork is Dead");
        }

        protected override void TakeDamage()
        {
            Debug.Log("Damage has been taken");
        }

        protected override void Move()
        {
            base.Move();
            Debug.Log("Yes Ork is moving");
        }
    }
}
