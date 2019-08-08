using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Facade
{
    class Evaporation
    {
        public void OpenValve()
        {
            Debug.Log("Opening the valve");
        }

        public void CloseValve()
        {
            Debug.Log("Closing the valve");
        }
    }
}
