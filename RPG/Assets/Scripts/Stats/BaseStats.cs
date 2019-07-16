using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BaseStats : MonoBehaviour
{
    [SerializeField] int startingLevel = 1;
    [SerializeField] CharacterClass characterClass;
    [SerializeField] Progression progression = null;
    [SerializeField] GameObject levelUpParticles;

    private int currentLevel = 0;
    Experience experience;

    public event Action onLevelUp;

    private void Start()
    {
        currentLevel = CalculateLevel();
        experience = GetComponent<Experience>();
        if(experience!=null)
        {
            experience.onExperienceGained += UpdateLevel;//subscribe delegate
        }
    }

    private void UpdateLevel()
    {
        int newLevel = CalculateLevel();
        if(newLevel>currentLevel)
        {
            currentLevel = newLevel;
            onLevelUp();
            GameObject levelUpEffect=Instantiate(levelUpParticles, transform);//relate the effect to the spawner;
            Destroy(levelUpEffect, 2f);
        }
    }

    public float GetStat(Stats stat)
    {
        return progression.GetStat(stat, characterClass, GetLevel());
    }

    public int GetLevel()
    {
        if(currentLevel<1)
        {
            currentLevel = CalculateLevel();//to prevent zero in currentLevel in the very beginnig of the script
            //we initialize the currentLevel
        }
        return currentLevel;
    }

    public int CalculateLevel()
    {
        //Experience experience = GetComponent<Experience>();
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
