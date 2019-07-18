using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Prototype
{
    class Sedan : ICar
    {
        int price;
        float length;
        int numberOfPeople;

        public Sedan(int price, float length, int numberOfPeople)
        {
            this.price = price;
            this.length = length;
            this.numberOfPeople = numberOfPeople;
        }

        public ICar Clone()
        {
            return new Sedan(price, length, numberOfPeople);
        }

        public void GetInfo()
        {
            Debug.Log($"new sedan with {price},{length},{numberOfPeople}");
        }
    }
}
