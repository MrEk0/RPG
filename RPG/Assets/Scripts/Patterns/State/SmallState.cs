using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.State
{
    class SmallState : ITiny
    {
        public int BaseDamage { get; set; } = 100;
        public int Strength { get; set; } = 20;

        public void GetLevel(TinyHero tiny)
        {
            Debug.Log(BaseDamage * Strength / 10);
            tiny.State = new AverageState();
        }
    }
}
