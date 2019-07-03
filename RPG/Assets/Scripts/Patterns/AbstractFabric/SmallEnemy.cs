using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.AbstractFabric
{
    class SmallEnemy : IBars
    {
        public void HealthBar()
        {
            Debug.Log("500 health");
        }

        public void ManaBar()
        {
            Debug.Log("200 mana pool");
        }
    }
}
