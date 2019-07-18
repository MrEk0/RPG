using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Builder
{
    class JeepCarBuilder : IBuilder
    {
        private Car car = new Car();

        public void SetEngine()
        {
            car.Engine = "Jeep";
        }

        public void SetMaxSpeed()
        {
            car.MaxSpeed = "180";
        }

        public void SetName()
        {
            car.Name = "Jeep F20";
        }

        public void SetPrice()
        {
            car.Price = "70000$";
        }

        public void SetTires()
        {
            car.Tires = "Bridgestone";
        }

        public Car GetCar()
        {
            return car;
        }
    }
}
