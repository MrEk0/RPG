using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Builder
{
    class Director
    {
        public Car SportCarConstruct(IBuilder builder)
        {
            builder.SetName();
            builder.SetEngine();
            builder.SetPrice();
            builder.SetMaxSpeed();
            return builder.GetCar();
        }

        public Car CityCarConstruct(IBuilder builder)
        {
            builder.SetName();
            builder.SetEngine();
            builder.SetPrice();
            builder.SetMaxSpeed();
            builder.SetTires();
            return builder.GetCar();
        }
    }
}
