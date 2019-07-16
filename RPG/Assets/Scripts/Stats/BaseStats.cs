using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    [SerializeField] int startingLevel = 1;
    [SerializeField] CharacterClass characterClass;
    [SerializeField] Progression progression = null;

    private void Update()
    {
        if(gameObject.tag=="Player")
        {
            print(GetLevel());
        }
    }

    public float GetStat(Stats stat)
    {
        return progression.GetStat(stat, characterClass, GetLevel());
    }

    public int GetLevel()
    {
        Experience experience = GetComponent<Experience>();
        if (experience == null)
            return startingLevel;//for our enemies because they don't have an experience

        float currentXP = experience.GetXP();
        int maxLevel = progression.GetLevel(Stats.ExperienceToLevelUp, characterClass);
        for(int level=1; level<=maxLevel; level++)//to avoid an exception
        {
            float XPToLevelUp = progression.GetStat(Stats.ExperienceToLevelUp, characterClass, level);
            if(XPToLevelUp>currentXP)//to return current level
            {
                return level;
            }
        }
        return maxLevel + 1;
    }
}
