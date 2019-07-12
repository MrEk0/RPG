using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Experience : MonoBehaviour, ISaveable
{
    [SerializeField] float pointsXP = 0;

    public void GainExperience(float xp)
    {
        pointsXP += xp;
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
