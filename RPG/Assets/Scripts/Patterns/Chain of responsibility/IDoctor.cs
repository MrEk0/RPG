using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Chain_of_responsibility
{
    interface IDoctor
    {
        //IDoctor NextDoctor(IDoctor doctor);
        void NextDoctor(IDoctor doctor);
        void Treat(Client client);
    }
}
