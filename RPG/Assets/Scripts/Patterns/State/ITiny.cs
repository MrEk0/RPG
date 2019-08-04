using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.State
{
    interface ITiny
    {
        int BaseDamage { get; set; }
        int Strength { get; set; }
        void GetLevel(TinyHero tiny);
    }
}
