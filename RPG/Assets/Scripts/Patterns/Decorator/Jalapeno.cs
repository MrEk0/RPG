using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Decorator
{
    class Jalapeno : Decorator
    {
        public Jalapeno( Pizza pizza) : base(pizza.Name+"+jalapeno", pizza)
        {
        }

        public override int GetCost()
        {
            return pizza.GetCost() + 2;
        }
    }
}
