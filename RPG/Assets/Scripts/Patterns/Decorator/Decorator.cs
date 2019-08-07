using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Decorator
{
    abstract class Decorator : Pizza
    {
        protected Pizza pizza;

        public Decorator(string name, Pizza pizza) : base(name)
        {
            this.pizza = pizza;
        }
    }
}
