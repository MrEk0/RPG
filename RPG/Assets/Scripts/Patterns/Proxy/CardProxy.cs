using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Proxy
{
    class CardProxy : IPayment
    {
        Cash cash;

        public CardProxy(Cash cash)
        {
            this.cash = cash;
        }

        public bool CheckAccess()
        {
            Debug.Log("Checking access");
            return true;
        }

        public void Pay()
        {
            if (CheckAccess())
            {
                cash = new Cash();
                cash.Pay();
            }
        }
    }
}
