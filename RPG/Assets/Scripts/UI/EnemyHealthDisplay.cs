using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EnemyHealthDisplay : MonoBehaviour
{
    Fighter fighter;
    //Health enemyHealth;
    Text healthText;

    private void Awake()
    {
        fighter = GameObject.FindGameObjectWithTag("Player").GetComponent<Fighter>();
        healthText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(fighter.GetTarget()!=null)
        healthText.text = String.Format("Health  {0:0}%", fighter.GetTarget().GetHealth());
        else
        {
            healthText.text = "No target";
        }
    }
}
