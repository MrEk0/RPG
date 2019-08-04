using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Iterator
{
    class Item
    {
        string name;

        public string Name { get; private set; }

        public Item(string name)
        {
            this.name = name;
            Name = name;
        }
    }
}
