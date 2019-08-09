using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Proxy
{
    class Cash : IPayment
    {
        public void Pay()
        {
            Debug.Log("Payment has been made by cash");
        }
    }
}
