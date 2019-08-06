using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Patterns.Memento
{
    class Game
    {
        private List<HeroMemento> mementos = new List<HeroMemento>();

        private int count = 0;

        public void Save(HeroMemento hero)
        {
            mementos.Add(hero);
            count++;
            Debug.Log(count);
        }

        public HeroMemento LoadLast()
        {
            int count = mementos.Count;
            return mementos[count - 1];
        }

        public HeroMemento LoadIndex(int index)
        {
            if (index > count || index<0)
                Debug.Log("Sorry it is not possible");
            else
            return mementos[index - 1];

            return null;
        }
    }
}
