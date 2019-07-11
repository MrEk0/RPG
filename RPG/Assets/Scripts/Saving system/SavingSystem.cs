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

        if(state.ContainsKey("lastSceneBuildIndex"))
        {
            int lastSceneBuildIndex = (int)state["lastSceneBuildIndex"];
            if(lastSceneBuildIndex!=SceneManager.GetActiveScene().buildIndex)
            {
                yield return SceneManager.LoadSceneAsync(lastSceneBuildIndex);
            }          
        }
       
        RestoreState(state);
    }

    public void Save(string fileName)
    {
        //string path = GetPathFromFile(fileName);
        //    Debug.Log("Save to " + path);
        //using (FileStream stream = File.Open(path, FileMode.Create))
        //{
        //    //Transform playerTransform = FindObjectOfType<Player>().transform;//fsfsdfsd

        //    BinaryFormatter formatter = new BinaryFormatter();
        //    //Serializable serializeVector = new Serializable(playerTransform.position);
        //    formatter.Serialize(stream, CaptureState());
        //    //byte[] buffer = SerializeVector(playerTransform.position);
        //    //stream.Write(buffer, 0, buffer.Length);

        //}
        Dictionary<string, object> state = LoadFile(fileName);
        CaptureState(state); //update the state
        SaveFile(fileName, state);//overwritte the state
    }

    private void SaveFile(string fileName, object state)
    {
        string path = GetPathFromFile(fileName);
        using (FileStream stream = File.Open(path, FileMode.Create))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            formatter.Serialize(stream, state);
        }
    }

    //private byte[] SerializeVector(Vector3 vector)
    //{
    //    byte[] bytes = new byte[3 * 4];
    //    BitConverter.GetBytes(vector.x).CopyTo(bytes, 0);
    //    BitConverter.GetBytes(vector.y).CopyTo(bytes, 4);
    //    BitConverter.GetBytes(vector.z).CopyTo(bytes, 8);
    //    return bytes;
    //}

    //private Vector3 DeserializeVector(byte[] buffer)
    //{
    //    Vector3 result = new Vector3();
    //    result.x = BitConverter.ToSingle(buffer, 0);
    //    result.y = BitConverter.ToSingle(buffer, 4);
    //    result.z = BitConverter.ToSingle(buffer, 8);
    //    return result;
    //}

    public void Load(string fileName)
    {
        //string path = GetPathFromFile(fileName);
        //if (File.Exists(path))
        //{
        //    Debug.Log("Load from " + path);
        //    using (FileStream stream = File.Open(path, FileMode.Open))
        //    {
        //        //byte[] buffer = new byte[stream.Length];
        //        //stream.Read(buffer, 0, buffer.Length);

        //        //Vector3 newPlayerPosition = DeserializeVector(buffer);
        //        Transform playerTransform = FindObjectOfType<Player>().transform;//fsfsdfsd

        //        BinaryFormatter formatter = new BinaryFormatter();
        //        //Serializable position=(Serializable)formatter.Deserialize(stream);
        //        //playerTransform.position = position.ToVector();
        //        RestoreState(formatter.Deserialize(stream));
        //    }
        //}
        RestoreState(LoadFile(fileName));
    }

    private Dictionary<string, object> LoadFile(string fileName)
    {
        string path = GetPathFromFile(fileName);
        if (File.Exists(path))
        {
            using (FileStream stream = File.Open(path, FileMode.Open))
            {
                Transform playerTransform = FindObjectOfType<Player>().transform;//fsfsdfsd

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
