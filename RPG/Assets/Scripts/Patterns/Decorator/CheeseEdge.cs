using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Decorator
{
    class CheeseEdge : Decorator
    {
        public CheeseEdge( Pizza pizza) : base(pizza.Name+"+cheese edge", pizza)
        {
        }

        public override int GetCost()
        {
            return pizza.GetCost() + 5;
        }
    }
}
