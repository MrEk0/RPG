using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Bridge
{
    class TVset : IDevice
    {
        float volume;

        public TVset()
        {
            volume = 0f;
        }

        public float GetVolume()
        {
            return volume;
        }

        public void GhangeVolume(float volume)
        {
            this.volume += volume;
        }

        public void SwitchOff()
        {
            Debug.Log("The tv has been switched off");
        }

        public void SwitchOn()
        {
            Debug.Log("The tv has been turned on");
        }
    }
}
