using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.State
{
    class AverageState : ITiny
    {
        public int BaseDamage { get; set; } = 150;
        public int Strength { get; set; } = 40;

        public void GetLevel(TinyHero tiny)
        {
            Debug.Log(BaseDamage * Strength / 10);
            tiny.State = new GrownState();
        }
    }
}
