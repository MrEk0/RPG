using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class CinemaController : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    private void OnEnable()
    {
        GetComponent<PlayableDirector>().played += DisableControl;
        GetComponent<PlayableDirector>().stopped += EnableControl;
    }

    private void OnDisable()
    {
        GetComponent<PlayableDirector>().played -= DisableControl;
        GetComponent<PlayableDirector>().stopped -= EnableControl;
    }

    void DisableControl(PlayableDirector pd)
    {
        print("Stop Moving!");
        player.GetComponent<Player>().enabled = false;
    }

    void EnableControl(PlayableDirector pd)
    {
        player.GetComponent<Player>().enabled = true;
        print("We are able to move!");
    }
}
