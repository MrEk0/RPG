using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.AbstractFabric
{
    class MeleeEnemy : IAttack
    {
        public void AttackType()
        {
            Debug.Log("Melee attack type");
        }
    }
}
