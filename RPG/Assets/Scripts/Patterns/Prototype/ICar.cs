using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Prototype
{
    interface ICar
    {
        ICar Clone();
        void GetInfo();
    }
}
