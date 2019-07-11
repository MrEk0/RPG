using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Progression", menuName = "Stats/Create a new Progression", order = 1)]
public class Progression : ScriptableObject
{
    [SerializeField] ProgressionCharacterClass[] characters = null;

    public int GetHealth(CharacterClass character, int level)
    {
        foreach(ProgressionCharacterClass progressClass in characters)
        {
            if(progressClass.characterClass==character)
            {
                return progressClass.health[level-1];
            }
        }
        return 0;
    }

    [System.Serializable]
    class ProgressionCharacterClass
    {
        public CharacterClass characterClass;
        public int[] health;
        public int[] damage;

        
    }
}
