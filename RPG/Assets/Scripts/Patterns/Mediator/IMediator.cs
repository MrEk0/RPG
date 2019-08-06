using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Mediator
{
    interface IMediator
    {
        void Notify(Aircraft aircraft, string msg);
    }
}
