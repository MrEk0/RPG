using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Chain_of_responsibility
{
    class ThroatDoctor:IDoctor
    {
        IDoctor nextDoctor;

        public void NextDoctor(IDoctor doctor)
        {
            nextDoctor = doctor;
        }

        //public IDoctor NextDoctor(IDoctor doctor)
        //{
        //    nextDoctor = doctor;
        //    return doctor;
        //}

        public void Treat(Client client)
        {
            if (client.Disease == "throat")
                Debug.Log("The Throat doctor treated");
            else
                nextDoctor.Treat(client);
        }
    }
}
