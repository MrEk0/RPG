using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Strategy
{
    class Main:MonoBehaviour
    {
        private void Start()
        {
            Weapon weapon = new Weapon(new Crystalis(), 10, 2);
            weapon.Apply();
            Weapon strongWeapon = new Weapon(new Bloodtorn(), 20, 4);
            strongWeapon.Apply();
        }
    }
}
