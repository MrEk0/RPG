using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Template_Method
{
    class Goblin : Enemies
    {
        protected override void Attack()
        {
            Debug.Log("Goblin Attacks player");
        }

        protected override void Death()
        {
            Debug.Log("Goblin is dead");
        }

        protected override void TakeDamage()
        {
            Debug.Log("Damage has been taken");
        }

        protected override void Move()
        {
            Debug.Log("Yes Goblin is flying");
        }
    }
}
