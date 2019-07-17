using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Adapter
{
    class SocketAdapter:IWire
    {
        ISocket socket;

        public SocketAdapter(ISocket socket)
        {
            this.socket = socket;
        }

        public void ChargeThroughWire()
        {
            socket.Charge();
        }
    }
}
