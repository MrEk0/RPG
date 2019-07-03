using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class LaunchTheIntro : MonoBehaviour
{
    private bool isTriggered = false;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Player") && !isTriggered)
        {
            GetComponent<PlayableDirector>().Play();
            //GetComponent<Collider>().isTrigger = false;
            isTriggered = true;
            collider.GetComponent<ActionSchedule>().CancelAllControls();
        }

    }
}
