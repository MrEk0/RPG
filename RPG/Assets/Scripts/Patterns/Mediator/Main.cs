using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Mediator
{
    class Main:MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Dispatcher dispatcher = new Dispatcher();

                Boing boing = new Boing(dispatcher);
                Airbus airbus = new Airbus(dispatcher);

                dispatcher.Boing = boing;
                dispatcher.Airbus = airbus;

                boing.Message("Boing's altitude is 1800");

                airbus.Message("Airbus 337 is on 2300 meters above the surface");
            }
        }
    }
}
