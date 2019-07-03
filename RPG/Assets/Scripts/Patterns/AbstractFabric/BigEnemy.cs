using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.AbstractFabric
{
    class BigEnemy : IBars
    {
        public void HealthBar()
        {
            Debug.Log("1000 health");
        }

        public void ManaBar()
        {
            Debug.Log("600 mana pool");
        }
    }
}
