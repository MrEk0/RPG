using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.State
{
    class GrownState : ITiny
    {
        public int BaseDamage { get; set; } = 200;
        public int Strength { get; set; } = 60;

        public void GetLevel(TinyHero tiny)
        {
            Debug.Log(BaseDamage * Strength / 10);
        }
    }
}
