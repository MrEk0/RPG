using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ObserverPattern
{
    class Main : MonoBehaviour
    {
        private void Start()
        {
            var channel = new SportChannel();
            var sub1 = new Subscriber1("Fedor");
            var sub2 = new Subscriber2("Petr");
            channel.AddSub(sub1);
            channel.AddSub(sub2);
            channel.NewVideo("Football");
        }
    }
}


