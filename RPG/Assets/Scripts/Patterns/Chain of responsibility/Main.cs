using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Chain_of_responsibility
{
    class Main:MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Client client1 = new Client("ear");
                Client client2 = new Client("nose");

                EarDoctor earDoctor = new EarDoctor();
                NoseDoctor noseDoctor = new NoseDoctor();
                ThroatDoctor throatDoctor = new ThroatDoctor();

                //throatDoctor.NextDoctor(noseDoctor).NextDoctor(earDoctor);//becasue of return in Idoctor;
                throatDoctor.NextDoctor(noseDoctor);
                noseDoctor.NextDoctor(earDoctor);

                throatDoctor.Treat(client1);
                noseDoctor.Treat(client2);
            }
        }
    }
}
