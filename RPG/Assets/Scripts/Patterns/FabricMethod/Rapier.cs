using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.FabricMethod
{
    class Rapier : IItem
    {
        public string Create()
        {
            //Debug.Log("Rapier has been created");
            return "Rapier has been created";
        }
    }
}
