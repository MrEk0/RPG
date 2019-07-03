using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace ObserverPattern
{
    interface ISubscriber
    {
        void Update(IChannel channel);
    }
}

