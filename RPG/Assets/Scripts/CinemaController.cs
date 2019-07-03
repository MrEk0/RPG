using System.Collections;
using System.Collections.Generic;
using UnityEngine.Playables;
using UnityEngine;

public class CinemaController : MonoBehaviour
{
    GameObject player;

    private void Start()
    {
        GetComponent<PlayableDirector>().played += DisableControl;
        GetComponent<PlayableDirector>().stopped += EnableControl;
        player = GameObject.FindGameObjectWithTag("Player");
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
