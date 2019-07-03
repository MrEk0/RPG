using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.AbstractFabric
{
    class Main:MonoBehaviour
    {
        private void Start()
        {
            Enemy smallEnemy = new Enemy(new LaneEnemy());
            smallEnemy.Attack();
            smallEnemy.Bars();

            Enemy bigEnemy = new Enemy(new MegaEnemy());
            bigEnemy.Attack();
            bigEnemy.Bars();
        }
    }
}
