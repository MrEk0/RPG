using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Bridge
{
    class SimpleRemote : Remote
    {
        public SimpleRemote(IDevice device) : base(device)
        {
        }

        public override void DecreaseVolume()
        {
            Debug.Log($"volume before {device.GetVolume()}");
            device.GhangeVolume( - 1f);
            Debug.Log($"volume after {device.GetVolume()}");
        }

        public override void IncreaseVolume()
        {
            Debug.Log($"volume before {device.GetVolume()}");
            device.GhangeVolume(device.GetVolume() + 1f);
            Debug.Log($"volume after {device.GetVolume()}");
        }
    }
}
