using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Progression", menuName = "Stats/Create a new Progression", order = 1)]
public class Progression : ScriptableObject
{
    [SerializeField] ProgressionCharacterClass[] characters = null;

    public float GetStat(Stats stat, CharacterClass character, int level)
    {
        foreach(ProgressionCharacterClass progressClass in characters)
        {
            if (progressClass.characterClass != character)
                continue;

            foreach (ProgressionStatsClass progressionStats in progressClass.stats)
            {
                if (progressionStats.stat != stat)
                    continue;

                if (progressionStats.levels.Length < level)
                    continue;

                return progressionStats.levels[level - 1];
            }
        }
        return 0;
    }

    [System.Serializable]
    class ProgressionCharacterClass
    {
        public CharacterClass characterClass;
        public ProgressionStatsClass[] stats;
        //public float[] health;
        //public int[] damage;        
    }

    [System.Serializable]
    class ProgressionStatsClass
    {
        public Stats stat;
        public float[] levels;
    }
}
