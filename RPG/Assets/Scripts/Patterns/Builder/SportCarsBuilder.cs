using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Builder
{
    class SportCarsBuilder : IBuilder
    {
        private Car car = new Car();

        public void SetEngine()
        {
            car.Engine = "Ferrari";
        }

        public void SetMaxSpeed()
        {
            car.MaxSpeed = "250";
        }

        public void SetName()
        {
            car.Name = "Ferrari 420";
        }

        public void SetPrice()
        {
            car.Price = "200000$";
        }

        public void SetTires()
        {
            car.Tires = "Pirreli";
        }

        public Car GetCar()
        {
            return car;
        }
    }
}
