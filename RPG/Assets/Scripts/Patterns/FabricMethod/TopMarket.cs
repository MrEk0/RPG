using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.FabricMethod
{
    class TopMarket : MarketPlace
    {
        public TopMarket(string name) : base(name) { }

        public override IItem Craft()
        {
            return new Axe();
        }
    }
}
