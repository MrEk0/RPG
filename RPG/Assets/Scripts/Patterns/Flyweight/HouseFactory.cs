using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Flyweight
{
    class HouseFactory
    {
        private List<House> houses = new List<House>();

        public HouseFactory()
        {
            houses.Add(new Project1House("gray", 2.5f ));
            houses.Add(new Project2House("darkRed", 3.0f));
        }

        public House GetHouse(int index)
        {
            return houses[index-1];
        }
    }
}
