using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Strategy
{
    class Bloodtorn : ICritical
    {
        public int initialDamage { get ; set ; }

        public void CritDamage(int multiplier)
        {
            Debug.Log($"{initialDamage * multiplier} critical damage by bloodtorn");
        }
    }
}
