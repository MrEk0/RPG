using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Flyweight
{
    class Project1House : House
    {
        public Project1House(string color, float ceilingHeight) : base(color, ceilingHeight)
        {
        }

        public override void BuildHouse(int stages, bool parkingSlot)
        {
            Debug.Log($"House1: {color}, Stages: {stages}, parkingSlot: {parkingSlot}");
        }
    }
}
