using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.FabricMethod
{
    abstract class MarketPlace
    {
        public abstract IItem Craft();

        public string Name { get; set; }

        public MarketPlace(string name)
        {
            Name = name;
        }
    }
}
