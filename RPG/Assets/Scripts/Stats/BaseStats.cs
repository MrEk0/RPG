﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseStats : MonoBehaviour
{
    [SerializeField] int startingLevel = 1;
    [SerializeField] CharacterClass characterClass;
    [SerializeField] Progression progression = null;

    public float GetStat(Stats stat)
    {
        return progression.GetStat(stat, characterClass, startingLevel);
    }

   //public float GetExperience()
   // {
   //     return progression.GetStat(stat, characterClass, startingLevel);
   // }
}
