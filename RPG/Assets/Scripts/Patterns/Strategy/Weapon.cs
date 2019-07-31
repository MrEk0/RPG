using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Strategy
{
    class Weapon
    {
        ICritical critical;
        int multiplier;

        public Weapon(ICritical critical, int damage, int multiplier)
        {
            this.critical = critical;
            this.critical.initialDamage = damage;
            this.multiplier = multiplier;
        }

        public void Apply()
        {
            critical.CritDamage(multiplier);
        }
    }
}
