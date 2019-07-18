using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Prototype
{
    class Main:MonoBehaviour
    {
        private void Start()
        {
            ICar jeep = new Jeep(1000, 2.5f, true);
            ICar cloneJeep = jeep.Clone();
            jeep.GetInfo();
            cloneJeep.GetInfo();

            ICar sedan = new Sedan(500, 3f, 4);
            ICar cloneSedan = sedan.Clone();
            sedan.GetInfo();
            cloneSedan.GetInfo();
        }
        
    }
}
