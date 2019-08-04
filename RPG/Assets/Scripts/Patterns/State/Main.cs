using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.State
{
    class Main:MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                TinyHero tiny = new TinyHero(new SmallState());
                tiny.GetDamage();
                tiny.GetDamage();
                tiny.GetDamage();
            }
        }
    }
}
