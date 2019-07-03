using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.FabricMethod
{
    class BottomMarket:MarketPlace
    {
        public BottomMarket(string name) : base(name) { }

        public override IItem Craft()
        {
            return new Rapier();
        }
    }
}
