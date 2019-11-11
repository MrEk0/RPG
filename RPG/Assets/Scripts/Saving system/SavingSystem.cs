using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Text;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine.SceneManagement;

public class SavingSystem : MonoBehaviour
{
    public IEnumerator LoadLastScene(string fileName)
    {
        Dictionary<string, object> state = LoadFile(fileName);

        int lastSceneBuildIndex = SceneManager.GetActiveScene().buildIndex;
        if (state.ContainsKey("lastSceneBuildIndex"))
        {
            lastSceneBuildIndex = (int)state["lastSceneBuildIndex"];
        }
        yield return SceneManager.LoadSceneAsync(lastSceneBuildIndex);//to get away from race conditions
        RestoreState(state);
    }

    public void Save(string fileName)
    {
        Dictionary<string, object> state = LoadFile(fileName);
        CaptureState(state); //update the state
        SaveFile(fileName, state);//overwritte the state
    }

    private void SaveFile(string fileName, object state)
    {
        string path = GetPathFromFile(fileName);
        print(path);
        using (FileStream stream = File.Open(path, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
        }
    }

    public void Load(string fileName)
    {
        RestoreState(LoadFile(fileName));
    }

    public void Delete(string fileName)
    {
        File.Delete(GetPathFromFile(fileName));
    }

    private Dictionary<string, object> LoadFile(string fileName)
    {
        string path = GetPathFromFile(fileName);
        if (File.Exists(path))
        {
            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                //Transform playerTransform = FindObjectOfType<Player>().transform;//fsfsdfsd

                BinaryFormatter formatter = new BinaryFormatter();
                return (Dictionary<string, object>)formatter.Deserialize(stream);
            }
        }
        return new Dictionary<string, object>();
    }

    private void CaptureState(Dictionary<string, object> state)
    {
        foreach (SaveableEntity saveable in FindObjectsOfType<SaveableEntity>())
        {
            state[saveable.GetUniqueIdentifier()] = saveable.CaptureState();
        }

        state["lastSceneBuildIndex"] = SceneManager.GetActiveScene().buildIndex;
    }

    private void RestoreState(Dictionary<string, object> state)
    {
        foreach (SaveableEntity saveable in FindObjectsOfType<SaveableEntity>())
        {
            string id = saveable.GetUniqueIdentifier();
            if(state.ContainsKey(id))
            saveable.RestoreState(state[id]);
        }
    }

    private string GetPathFromFile(string fileName)
    {
        return Path.Combine(Application.persistentDataPath, fileName + ".sav");
    }
}
