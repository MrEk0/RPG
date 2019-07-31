using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Strategy
{
    public interface ICritical
    {
        int initialDamage { get; set; }
        void CritDamage(int multiplier);
    }
}
