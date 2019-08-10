using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Bridge
{
    class HighTechRemote : Remote
    {
        public HighTechRemote(IDevice device) : base(device)
        {
        }

        public override void DecreaseVolume()
        {
            Debug.Log($"volume after {device.GetVolume()}");
            device.GhangeVolume( - 2f);
            Debug.Log($"volume after {device.GetVolume()}");
        }

        public override void IncreaseVolume()
        {
            Debug.Log($"volume after {device.GetVolume()}");
            device.GhangeVolume(device.GetVolume() + 2f);
            Debug.Log($"volume after {device.GetVolume()}");
        }

        public void Mute()
        {
            device.GhangeVolume(-device.GetVolume());
            Debug.Log($"volume after {device.GetVolume()}");
        }
    }
}
