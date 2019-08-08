using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Facade
{
    class Main:MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Merging merging = new Merging();
                Evaporation evaporation = new Evaporation();
                Heating heating = new Heating();

                MultichefFacade facade = new MultichefFacade(merging, evaporation, heating);

                Client client = new Client();
                client.Cooking(facade);
            }
        }
    }
}
