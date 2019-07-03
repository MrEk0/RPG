using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIPath : MonoBehaviour
{
    [SerializeField] float pointSize = 0.5f;

    private void OnDrawGizmos()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int j = GetNextChildPosition(i);
            Gizmos.DrawSphere(GetChildPosition(i), pointSize);         
            Gizmos.DrawLine(GetChildPosition(i), GetChildPosition(j));
        }
    }

    public int GetNextChildPosition(int i)
    {
        if(i+1 == transform.childCount)
        {
            return 0;
        }
        return i + 1;
    }

    public Vector3 GetChildPosition(int i)
    {
        return transform.GetChild(i).position;
    }
 
}
