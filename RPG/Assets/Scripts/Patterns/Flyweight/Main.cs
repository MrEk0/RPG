using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Flyweight
{
    class Main:MonoBehaviour
    {
        //int stages = 15;
        //bool parkingSlot = false;

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                HouseFactory house = new HouseFactory();

                int stages = 15;
                bool parkingSlot = false;
                House1Build(house,  stages, ref parkingSlot);
                House2Build(house, ref stages, ref parkingSlot);
                Debug.Log(stages);

            }
        }

        private static void House1Build(HouseFactory house, int stages, ref bool parkingSlot)
        {
            House house1 = house.GetHouse(1);

            if (house1 != null)
            {
                for (int i = 0; i < 5; i++)
                {
                    house1.BuildHouse(stages, parkingSlot);
                    stages++;
                    parkingSlot = !parkingSlot;
                }
            }
        }

        private static void House2Build(HouseFactory house, ref int stages, ref bool parkingSlot)
        {
            House house2 = house.GetHouse(2);

            if (house2 != null)
            {
                for (int i = 0; i < 5; i++)
                {
                    house2.BuildHouse(stages, parkingSlot);
                    stages += 2;
                }
            }
        }
    }
}
