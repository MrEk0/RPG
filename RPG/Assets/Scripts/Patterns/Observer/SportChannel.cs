using ObserverPattern;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    class SportChannel : IChannel
    {
        List<ISubscriber> subs = new List<ISubscriber>();
        public string PublicOfTheVideo { get; set; }

        public void AddSub(ISubscriber sub)
        {
            subs.Add(sub);
        }

        public void NotifyTheSub()
        {
            foreach (ISubscriber suber in subs)
            {
                suber.Update(this);
                Debug.Log("New video came out!");
            }
        }

        public void RemoveSub(ISubscriber sub)
        {
            subs.Remove(sub);
        }

        public void NewVideo(string publicOfTheVideo)
        {
            PublicOfTheVideo = publicOfTheVideo;
            NotifyTheSub();
        }
    }
}

