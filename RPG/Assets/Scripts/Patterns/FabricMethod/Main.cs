using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.FabricMethod
{
    class Main:MonoBehaviour
    {
        private void Start()
        {
            MarketPlace[] marketPlaces = { new BottomMarket("Bottom"), new TopMarket("Top") };
            foreach(MarketPlace marketplace in marketPlaces)
            {
                IItem item = marketplace.Craft();
                Debug.Log( item.Create());
            }
        }
    }
}
