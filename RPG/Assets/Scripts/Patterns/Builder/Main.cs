using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Builder
{
    class Main:MonoBehaviour
    {
        private void Start()
        {
            Director pasha = new Director();
            IBuilder carBuilder = new SportCarsBuilder();
            Car sportCar= pasha.SportCarConstruct(carBuilder);
            Debug.Log($"{sportCar.Engine}, {sportCar.MaxSpeed},{sportCar.Name},{sportCar.Price},{sportCar.Tires}");

            IBuilder jeepCarBuilder = new JeepCarBuilder();
            Car jeepCar = pasha.CityCarConstruct(jeepCarBuilder);
            Debug.Log($"{jeepCar.Engine}, {jeepCar.MaxSpeed},{jeepCar.Name},{jeepCar.Price},{jeepCar.Tires}");
        }
    }
}
