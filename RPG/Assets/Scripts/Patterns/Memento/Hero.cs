using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Memento
{
    class Hero
    {
        int bullets = 10;
        int health = 100;
        int speed = 50;

        public void Shoot()
        {
            bullets--;
            Debug.Log("remaining bullets "+bullets);
        }

        public void GetShot()
        {
            health -= 10;
            speed -= 5;
            Debug.Log($"remaining health {health}, speed {speed}");
        }

        public HeroMemento CaptureState()
        {
            Debug.Log($"Save {bullets} bullets, {speed} speed, {health} healths");
            return new HeroMemento(bullets, speed, health);
        }

        public void RestoreState(HeroMemento memento)
        {
            health = memento.Health;
            bullets = memento.Bullets;
            speed = memento.Speed;
            Debug.Log($"Restore game data {health} healths, {speed} speed, {bullets} bullets");
        }
    }
}
