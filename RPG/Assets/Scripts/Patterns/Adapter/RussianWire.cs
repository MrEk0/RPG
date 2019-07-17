using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Adapter
{
    class RussianWire : IWire
    {
        public void ChargeThroughWire()
        {
            Debug.Log("Russian type of wire has been hooked up");
        }
    }
}
