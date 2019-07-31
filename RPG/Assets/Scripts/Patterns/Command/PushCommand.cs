using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Command
{
    class PushCommand:ICommand
    {
        CrusaderArmy crusaderArmy;

        public PushCommand(CrusaderArmy crusader)
        {
            crusaderArmy = crusader;
        }

        public void Execute()
        {
            crusaderArmy.Push();
        }
    }
}
