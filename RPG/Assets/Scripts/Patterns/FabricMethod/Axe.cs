using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Patterns.FabricMethod
{
    public class Axe : IItem
    {
        public string Create()
        {
            //Debug.Log("Axe has been created");
            return "Axe has been created";
        }
    }
}

