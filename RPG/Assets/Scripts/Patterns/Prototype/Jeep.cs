using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Prototype
{
    class Jeep : ICar
    {
        int price;
        float length;
        bool isOfRoad;

        public Jeep(int price, float  length, bool isOfRoad)
        {
            this.price = price;
            this.length = length;
            this.isOfRoad = isOfRoad;
        }

        public ICar Clone()
        {
            return new Jeep(price, length, isOfRoad);
        }

        public void GetInfo()
        {
            Debug.Log($"new jeep with {price},{length},{isOfRoad}");
        }
    }
}
