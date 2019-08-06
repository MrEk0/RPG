using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assets.Scripts.Patterns.Memento
{
    class HeroMemento
    {
        public int Bullets { get; private set; }
        public int Speed { get; private set; }
        public int Health { get; private set; }

        public HeroMemento(int bullets, int speed, int health)
        {
            Bullets = bullets;
            Speed = speed;
            Health = health;
        }
    }
}
