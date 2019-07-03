using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.AbstractFabric
{
    class Enemy
    {
        IAttack attack;
        IBars bar;

        public Enemy(IEnemiesSpawner enemy)
        {
            attack = enemy.InstallAttackType();
            bar = enemy.InstallBars();
        }

        public void Attack()
        {
            attack.AttackType();
        }

        public void Bars()
        {
            bar.HealthBar();
            bar.ManaBar();
        }
    }
}
