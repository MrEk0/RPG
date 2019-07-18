using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Builder
{
    interface IBuilder
    {
        void SetName();
        void SetPrice();
        void SetEngine();
        void SetTires();
        void SetMaxSpeed();
        Car GetCar();
    }
}
