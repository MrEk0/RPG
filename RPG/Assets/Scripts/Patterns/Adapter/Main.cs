using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Adapter
{
    class Main:MonoBehaviour
    {
        private void Start()
        {
            Phone phone = new Phone();
            RussianWire wire = new RussianWire();
            phone.Charge(wire);
            EuropeanSocket socket = new EuropeanSocket();
            IWire europeanSocket = new SocketAdapter(socket);
            phone.Charge(europeanSocket);
        }
    }
}
