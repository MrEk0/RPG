using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Decorator
{
    class Margarita : Pizza
    {
        public Margarita():base("Margarita")
        {

        }

        public override int GetCost()
        {
            return 5;
        }
    }
}
