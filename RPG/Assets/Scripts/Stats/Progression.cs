using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Progression", menuName = "Stats/Create a new Progression", order = 1)]
public class Progression : ScriptableObject
{
    [SerializeField] ProgressionCharacterClass[] characters = null;

    Dictionary<CharacterClass, Dictionary<Stats, float[]>> lookupDictionary;//to build it only one time

    public float GetStat(Stats stat, CharacterClass character, int level)
    {
        BuildLookup();

       float[] levels=lookupDictionary[character][stat];
        if(levels.Length<level)
        {
            return 0;
        }
        return levels[level - 1];
    }

    private void BuildLookup()
    {
        if (lookupDictionary != null)
            return;

        lookupDictionary = new Dictionary<CharacterClass, Dictionary<Stats, float[]>>();

        foreach (ProgressionCharacterClass progressClass in characters)
        {
            var statLookupDictionary = new Dictionary<Stats, float[]>();

            foreach (ProgressionStatsClass progressionStats in progressClass.stats)
            {
                statLookupDictionary[progressionStats.stat] = progressionStats.levels;
            }
            lookupDictionary[progressClass.characterClass] = statLookupDictionary;
        }
    }

    [System.Serializable]
    class ProgressionCharacterClass
    {
        public CharacterClass characterClass;
        public ProgressionStatsClass[] stats;       
    }

    [System.Serializable]
    class ProgressionStatsClass
    {
        public Stats stat;
        public float[] levels;
    }
}
