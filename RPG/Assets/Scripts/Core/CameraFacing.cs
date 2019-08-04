using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CameraFacing : MonoBehaviour
{
    Text damageText;
    private void Awake()
    {
        damageText = GetComponentInChildren<Text>();
    }
    // Update is called once per frame
    void Update()
    {
        transform.forward = Camera.main.transform.forward;
    }

    public void Text(float damage)////
    {
        damageText.text = damage.ToString();
    }
}
