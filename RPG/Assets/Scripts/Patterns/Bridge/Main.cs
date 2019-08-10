using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Bridge
{
    class Main:MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                SimpleRemote remote = new SimpleRemote(new Radio());
                remote.SwitchOn();
                remote.IncreaseVolume();

                remote = new SimpleRemote(new TVset());
                remote.SwitchOn();
                remote.IncreaseVolume();
                remote.DecreaseVolume();

                HighTechRemote remote1 = new HighTechRemote(new TVset());
                remote1.SwitchOn();
                remote1.IncreaseVolume();
                remote1.Mute();
                remote1.SwitchOff();
            }
        }
    }
}
