using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavingWrapper : MonoBehaviour
{
    const string fileName = "filedirectory";

    [SerializeField] float fadeInTime = 1f;

    SavingSystem savingSystem;

    private void Awake()
    {
        savingSystem = GetComponent<SavingSystem>();
        StartCoroutine(LoadLastScene());
    }

    private IEnumerator LoadLastScene()
    {
        yield return savingSystem.LoadLastScene(fileName);
        Fader fader = FindObjectOfType<Fader>();
        fader.FadeOutImmediate();//black screen at the brginning
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
        if(Input.GetKeyDown(KeyCode.Delete))
        {
            Delete();
        }
    }

    public void Load()
    {
        savingSystem.Load(fileName);
    }

    public void Save()
    {
        savingSystem.Save(fileName);
    }

    public void Delete()
    {
        savingSystem.Delete(fileName);
    }
}
