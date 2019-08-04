using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.State
{
    class TinyHero
    {
        public ITiny State { get; set; }

        public TinyHero(ITiny tiny)
        {
            State = tiny;
        }

        public void GetDamage()
        {
            State.GetLevel(this);
        }
    }
}
