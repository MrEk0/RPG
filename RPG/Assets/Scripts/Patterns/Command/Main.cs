using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Command
{
    class Main:MonoBehaviour
    {
        private void Start()
        {
            CrusaderArmy crusaderArmy = new CrusaderArmy();
            DoctorArmy doctorArmy = new DoctorArmy();
            ArmedArmy armedArmy = new ArmedArmy();

            Player player = new Player();

            List<ICommand> commands = new List<ICommand>();
            commands.Add(new AttackCommand(armedArmy));
            commands.Add(new PushCommand(crusaderArmy));
            commands.Add(new HealCommand(doctorArmy));

            player.SetCommand(new MacroCommand(commands));
            player.WarButton();
        }
    }
}
