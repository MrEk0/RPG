using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.AbstractFabric
{
    class MegaEnemy : IEnemiesSpawner
    {
        public IAttack InstallAttackType()
        {
            return new RangeEnemy();
        }

        public IBars InstallBars()
        {
            return new BigEnemy();
        }
    }
}
