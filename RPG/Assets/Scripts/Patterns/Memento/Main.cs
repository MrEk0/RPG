using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Memento
{
    class Main:MonoBehaviour
    {
        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Hero hero = new Hero();
                hero.Shoot();
                hero.Shoot();
                hero.GetShot();

                Game game = new Game();
                game.Save(hero.CaptureState());

                hero.Shoot();
                hero.GetShot();
                game.Save(hero.CaptureState());

                hero.RestoreState(game.LoadLast());
                hero.RestoreState(game.LoadIndex(1));
            }
        }
    }
}
