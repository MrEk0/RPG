using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Decorator
{
    abstract class Pizza
    {
        public Pizza(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public abstract int GetCost();

    }
}
