using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Command
{
    class AttackCommand:ICommand
    {
        ArmedArmy armedArmy;

        public AttackCommand(ArmedArmy attack)
        {
            armedArmy = attack;
        }

        public void Execute()
        {
            armedArmy.Attack();
        }
    }
}
