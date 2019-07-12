using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class XPDisplay : MonoBehaviour
{
    Experience experience;
    Text xpText;

    // Start is called before the first frame update
    private void Awake()
    {
        experience = GameObject.FindGameObjectWithTag("Player").GetComponent<Experience>();
        xpText = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        xpText.text = String.Format("Experience {0}", experience.GetXP());
    }
}
