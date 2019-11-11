using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] int nextScene;
    [SerializeField] Transform spawnPoint;
    [SerializeField] SpawnPoints spawnPointDestination;
    [SerializeField] float fadeOutTime = 3f;
    [SerializeField] float fadeInTime = 2f;
    [SerializeField] float fadeWaitTime = 3f;

    enum SpawnPoints
    {
        A, B, C, D
    }

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Player"))
        {
            StartCoroutine(Transition());
        }
    }

    IEnumerator Transition()
    {
        DontDestroyOnLoad(gameObject);

        Fader fader = FindObjectOfType<Fader>();
        SavingWrapper savingWrapper = FindObjectOfType<SavingWrapper>();

        //remove player's control to escape of race condition
        Player playerMovement= GameObject.FindWithTag("Player").GetComponent<Player>();
        playerMovement.enabled = false;

        yield return fader.FadeOut(fadeOutTime);

        savingWrapper.Save();

        yield return SceneManager.LoadSceneAsync(nextScene);
        //remove player's control in a new scene
        Player newPlayerMovement = GameObject.FindWithTag("Player").GetComponent<Player>();
        newPlayerMovement.enabled = false;

        savingWrapper.Load();

        Portal otherPortal = GetOtherPortal();
        PlayerUpdate(otherPortal);

        savingWrapper.Save();

        yield return new WaitForSeconds(fadeWaitTime);
        fader.FadeIn(fadeInTime);

        //return control
        newPlayerMovement.enabled = true;
        Destroy(gameObject);
    }

    private Portal GetOtherPortal()
    {
        foreach(Portal portal in FindObjectsOfType<Portal>())
        {
            if (portal == this)
                continue;
            if (portal.spawnPointDestination == spawnPointDestination)
            {
                return portal;
            }                      
        }

        return null;
    }

    private void PlayerUpdate(Portal otherPortal)
    {
        Player player = FindObjectOfType<Player>();
        player.GetComponent<NavMeshAgent>().enabled = false;
        player.transform.position = otherPortal.spawnPoint.position;
        player.transform.rotation = otherPortal.spawnPoint.rotation;
        player.GetComponent<NavMeshAgent>().enabled = true;
    }

    public float GetFadeInTime()
    {
        return fadeInTime;
    }
}
