using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Adapter
{
    class Phone
    {
        public void Charge(IWire wire)
        {
            wire.ChargeThroughWire();
        }
    }
}
