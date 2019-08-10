using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Bridge
{
    interface IDevice
    {
        void SwitchOff();
        void SwitchOn();
        float GetVolume();
        void GhangeVolume(float volume);
    }
}
