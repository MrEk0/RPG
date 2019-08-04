using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Iterator
{
    interface IItemEnumerator
    {
        bool MoveNext();
        Item Current { get; }
        //void Reset();
    }
}
