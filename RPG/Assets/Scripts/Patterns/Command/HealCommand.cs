using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Command
{
    class HealCommand:ICommand
    {
        DoctorArmy doctorArmy;

        public HealCommand(DoctorArmy doctor)
        {
            doctorArmy = doctor;
        }

        public void Execute()
        {
            doctorArmy.Heal();
        }
    }
}
