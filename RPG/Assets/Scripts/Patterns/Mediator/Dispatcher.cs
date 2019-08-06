using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Mediator
{
    class Dispatcher : IMediator
    {
        public Boing Boing { get; set; }
        public Airbus Airbus { get; set; }

        //public Dispatcher(Aircraft boing, Airbus airbus)
        //{
        //    this.boing = (Boing)boing;
        //    this.airbus = airbus;
        //}

        public void Notify(Aircraft aircraft, string msg)
        {
            if (aircraft==Boing)
                Airbus.Notify(msg);
            else if (aircraft==Airbus)
                Boing.Notify(msg);
        }
    }
}
