using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Template_Method
{
    class Main:MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Ork ork = new Ork();
                Goblin goblin = new Goblin();

                ork.Create();
                goblin.Create();
            }
            //Ork ork = new Ork();
            //Goblin goblin = new Goblin();

            //ork.Create();
            //goblin.Create();
        }
    }
}
