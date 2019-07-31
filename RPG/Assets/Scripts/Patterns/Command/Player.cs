using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Command
{
    class Player
    {
        ICommand command;

        public void SetCommand(ICommand command)
        {
            this.command = command;
        }

        public void WarButton()
        {
            if (command!=null)
            {
                command.Execute();
            }
        }
    }
}
