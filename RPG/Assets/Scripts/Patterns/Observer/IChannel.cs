using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    interface IChannel
    {
        void AddSub(ISubscriber sub);
        void RemoveSub(ISubscriber sub);
        void NotifyTheSub();
    }
}

