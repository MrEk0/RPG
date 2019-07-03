using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.AbstractFabric
{
    class LaneEnemy : IEnemiesSpawner
    {
        public IAttack InstallAttackType()
        {
            return new MeleeEnemy();
        }

        public IBars InstallBars()
        {
            return new SmallEnemy();
        }
    }
}
