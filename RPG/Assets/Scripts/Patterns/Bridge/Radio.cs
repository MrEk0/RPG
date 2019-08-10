using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Bridge
{
    class Radio : IDevice
    {
        float volume;

        public Radio()
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
            Debug.Log("The radio has been switched off");
        }

        public void SwitchOn()
        {
            Debug.Log("The radio has been turned on");
        }
    }
}
