using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Decorator
{
    class Salami : Pizza
    {
        public Salami() : base("Salami")
        {

        }

        public override int GetCost()
        {
            return 7;
        }
    }
}
