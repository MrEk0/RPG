using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Bridge
{
    abstract class Remote
    {
        protected IDevice device;

        public Remote(IDevice device)
        {
            this.device = device;
        }

        public abstract void IncreaseVolume();
        public abstract void DecreaseVolume();

        public virtual void SwitchOn()
        {
            device.SwitchOn();
        }

        public virtual void SwitchOff()
        {
            device.SwitchOff();
        }
    }
}
