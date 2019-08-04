using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Iterator
{
    class Main:MonoBehaviour
    {
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                SecretShop shop = new SecretShop();

                shop.AddItem(new Item("Axe"));
                shop.AddItem(new Item("Rapier"));
                shop.AddItem(new Item("Sword"));
                shop.AddItem(new Item("Bow"));

                Player player = new Player();
                player.SeeItems(shop);
            }
        }
    }
}
