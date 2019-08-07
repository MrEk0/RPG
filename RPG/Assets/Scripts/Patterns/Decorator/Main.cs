using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Decorator
{
    class Main:MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Pizza pizza1 = new Margarita();
                pizza1 = new CheeseEdge(pizza1);
                Debug.Log($"Cost: {pizza1.GetCost()}, Name {pizza1.Name}");

                Pizza pizza2 = new Salami();
                pizza2 = new Jalapeno(pizza2);
                Debug.Log($"Cost: {pizza2.GetCost()}, Name {pizza2.Name}");
            }
        }
    }
}
