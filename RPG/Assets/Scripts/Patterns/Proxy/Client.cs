using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Proxy
{
    class Client
    {
        public void Purchase(IPayment payment)
        {
            payment.Pay();
        }
    }
}
