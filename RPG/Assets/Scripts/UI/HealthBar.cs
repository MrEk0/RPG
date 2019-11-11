using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Health health;
    [SerializeField] RectTransform foregroundTransform;
    [SerializeField] Canvas healthBarCanvas;



    // Update is called once per frame
    void Update()
    {
        if (Mathf.Approximately(health.GetHealthFraction(), 1) || Mathf.Approximately(health.GetHealthFraction(), 0))
        { 
            healthBarCanvas.enabled = false;
            return;
        }

        healthBarCanvas.enabled = true;
        foregroundTransform.localScale=new Vector3(health.GetHealthFraction(), 1, 1);
    }
}
