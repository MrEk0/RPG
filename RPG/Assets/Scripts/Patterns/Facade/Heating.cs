using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Facade
{
    class Heating
    {
        public void IncreaseTemperature()
        {
            Debug.Log("Increase the temperature till appropriate value");
        }

        public void DeacreaseTemperature()
        {
            Debug.Log("Decrease the temperature to the null");
        }
    }
}
