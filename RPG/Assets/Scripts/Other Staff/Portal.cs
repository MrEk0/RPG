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
        yield return fader.FadeOut(fadeOutTime);

        SavingWrapper savingWrapper = FindObjectOfType<SavingWrapper>();
        savingWrapper.Save();

        yield return SceneManager.LoadSceneAsync(nextScene);

        savingWrapper.Load();

        Portal otherPortal = GetOtherPortal();
        PlayerUpdate(otherPortal);

        savingWrapper.Save();

        yield return fader.FadeIn(fadeInTime);

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
