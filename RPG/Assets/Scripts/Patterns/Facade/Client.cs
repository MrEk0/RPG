using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Facade
{
    class Client
    {
        public void Cooking(MultichefFacade facade)
        {
            facade.Start();
            facade.Finish();
        }
    }
}
