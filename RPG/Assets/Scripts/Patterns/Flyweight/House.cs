using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Flyweight
{
    abstract class House
    {
        protected string color;
        protected float ceilingHeight;

        public House(string color, float ceilingHeight)
        {
            this.color = color;
            this.ceilingHeight = ceilingHeight;
        }

        public abstract void BuildHouse(int stages, bool parkingSlot);
    }
}
