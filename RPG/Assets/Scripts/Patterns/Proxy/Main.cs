using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Proxy
{
    class Main:MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Client client = new Client();
                Cash cash = new Cash();
                client.Purchase(cash);

                Debug.Log("using proxy");
                CardProxy card = new CardProxy(cash);
                client.Purchase(card);
            }
        }
    }
}
