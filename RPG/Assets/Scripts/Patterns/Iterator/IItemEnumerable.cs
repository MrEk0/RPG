using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Iterator
{
    interface IItemEnumerable
    {
        IItemEnumerator GetItemEnumerator();
        int Count { get; }
        Item GetItem(int index);
        //Item this[int index] { get; }//property
    }
}
