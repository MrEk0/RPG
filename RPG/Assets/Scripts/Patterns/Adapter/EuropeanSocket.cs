using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Adapter
{
    class EuropeanSocket : ISocket
    {
        public void Charge()
        {
            Debug.Log("Charge by european socket");
        }
    }
}
