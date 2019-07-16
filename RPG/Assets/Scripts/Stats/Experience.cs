using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Experience : MonoBehaviour, ISaveable
{
    [SerializeField] float pointsXP = 0;

    public event Action onExperienceGained;

    public void GainExperience(float xp)
    {
        pointsXP += xp;
        onExperienceGained();
    }

    public float GetXP()
    {
        return pointsXP;
    }

    public object CaptureState()
    {
        return pointsXP;
    }

    public void RestoreState(object state)
    {
        pointsXP = (float)state;
    }
}
