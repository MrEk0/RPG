using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteAlways]
public class SaveableEntity : MonoBehaviour
{
    [SerializeField] string uniqueUdentifier = "";
    static Dictionary<string, SaveableEntity> globalLookup = new Dictionary<string, SaveableEntity>();

    public string GetUniqueIdentifier()
    {
        return uniqueUdentifier;
    }

    public object CaptureState()
    {
        Dictionary<string, object> state = new Dictionary<string, object>();
        foreach (ISaveable saveable in GetComponents<ISaveable>())  
        {
            state[saveable.GetType().ToString()] = saveable.CaptureState();//capture the own state and the state in a dictionary by a string
        }
        return state;
    }

    public void RestoreState(object state)
    {
        Dictionary<string, object> stateDict = (Dictionary<string, object>)state;
        foreach (ISaveable saveable in GetComponents<ISaveable>())  
        {
            string stringType = saveable.GetType().ToString();
            if(stateDict.ContainsKey(stringType))
            {
                saveable.RestoreState(stateDict[stringType]);
            }
        }
        //Serializable position = (Serializable)state;
        //transform.position = position.ToVector();
        //GetComponent<ActionSchedule>().CancelAllControls();
    }

#if UNITYE_DITOR
    private void Update()
    {
        if (Application.IsPlaying(gameObject))
            return;
        if (string.IsNullOrEmpty(gameObject.scene.path))//are we in prefab mode
            return;

        SerializedObject serializedObject = new SerializedObject(this);
        SerializedProperty property= serializedObject.FindProperty("uniqueUdentifier");

        if(string.IsNullOrEmpty(property.stringValue) && !IsUnique(property.stringValue))
        {
            property.stringValue = Guid.NewGuid().ToString();
            serializedObject.ApplyModifiedProperties();
        }

        globalLookup[property.stringValue] = this;  
    }
#endif

    private bool IsUnique(string canditate)
    {
        if (!globalLookup.ContainsKey(canditate))
            return true;

        if (globalLookup[canditate] == this)   //Is this unique?
            return true;

        if(globalLookup[canditate]==null)   //Scene load problem. If it was deleted during the change scenes we remove it
        {
            globalLookup.Remove(canditate);
            return true;
        }

        if(globalLookup[canditate].GetUniqueIdentifier()!=canditate)//something went wrong. Unexpectable changes
        {
            globalLookup.Remove(canditate);
            return true;
        }
            

        return false;
    }
}
