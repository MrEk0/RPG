using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ObserverPattern
{
    class Subscriber2 : ISubscriber
    {
        public string Name { get; private set; }

        public Subscriber2(string name)
        {
            Name = name;
        }

        public void Update(IChannel channel)
        {
            if ((channel as SportChannel).PublicOfTheVideo == "Football")
            {
                Debug.Log("Nooo! "+Name);
            }
        }
    }
}


