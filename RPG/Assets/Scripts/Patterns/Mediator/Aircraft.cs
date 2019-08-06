using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Mediator
{
    abstract class Aircraft
    {
        protected IMediator mediator;

        public Aircraft(IMediator mediator)
        {
            this.mediator = mediator;
        }

        public virtual void Message(string msg)
        {
            mediator.Notify(this, msg);
        }

        public abstract void Notify(string msg);
    }
}
