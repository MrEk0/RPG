using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Iterator
{
    class ShopIterator : IItemEnumerator
    {
        IItemEnumerable item;
        int position = -1;

        public ShopIterator(IItemEnumerable item)
        {
            this.item = item;
        }

        public Item Current
        {
            get
            {
                if (position == -1 || position >= item.Count)
                    throw new InvalidOperationException();
                return item.GetItem(position);
            }
        }

        public bool MoveNext()
        {
            if (position < item.Count-1)
            {
                position++;
                return true;
            }
            else
                return false;
        }

        //public void Reset()
        //{
        //    position = 0;
        //}
    }
}
