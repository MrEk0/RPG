using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Iterator
{
    class Player
    {
        public void SeeItems(SecretShop secretShop)
        {
            IItemEnumerator enumerator= secretShop.GetItemEnumerator();
            while(enumerator.MoveNext())
            {
                Item item = enumerator.Current;
            }
        }
    }
}
