using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class XPLevelDisplay : MonoBehaviour
{
    Text xpLevel;
    BaseStats baseStats;

    private void Awake()
    {
        xpLevel = GetComponent<Text>();
        baseStats = GameObject.FindGameObjectWithTag("Player").GetComponent<BaseStats>();
    }

    // Update is called once per frame
    void Update()
    {
        xpLevel.text = String.Format("Level {0}", baseStats.GetLevel());
    }
}
