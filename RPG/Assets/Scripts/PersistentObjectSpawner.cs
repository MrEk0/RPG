using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersistentObjectSpawner : MonoBehaviour
{

    [SerializeField] GameObject persistObjectPrefab;

    static bool isSpawned = false;

    private void Start()
    {
        if (isSpawned) return;
        InstantiatePrefabs();
        isSpawned = true;
    }

    private void InstantiatePrefabs()
    {
        GameObject persistObject = Instantiate(persistObjectPrefab);
        DontDestroyOnLoad(persistObject);
    }
}
