using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Mediator
{
    class Boing : Aircraft
    {
        public Boing(IMediator mediator) : base(mediator)
        {
        }

        //public override void Message(string msg)
        //{
        //    mediator.Notify(this, msg);
        //}

        public override void Notify(string msg)
        {
            Debug.Log("Message to the boing: " + msg);
        }
    }
}
