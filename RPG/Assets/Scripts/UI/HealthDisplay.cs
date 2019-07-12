using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class HealthDisplay : MonoBehaviour
{
    Health health;
    Text healthPoints;

    private void Awake()
    {
        health = GameObject.FindGameObjectWithTag("Player").GetComponent<Health>();
        healthPoints = GetComponent<Text>();
    }

    private void Update()
    {
        healthPoints.text = String.Format("Health  {0:0}%", health.GetHealth());//to ger rid of decimal;

    }
}
