using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingWrapper : MonoBehaviour
{
    const string fileName = "filedirectory";

    [SerializeField] float fadeInTime = 1f;

    private IEnumerator Start()
    {
        Fader fader = FindObjectOfType<Fader>();
        fader.FadeOutImmediate();//black screen at the brginning
        yield return GetComponent<SavingSystem>().LoadLastScene(fileName);
        yield return fader.FadeIn(fadeInTime);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            Save();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
            Load();
        }
    }

    public void Load()
    {
        GetComponent<SavingSystem>().Load(fileName);
    }

    public void Save()
    {
        GetComponent<SavingSystem>().Save(fileName);
    }
}
