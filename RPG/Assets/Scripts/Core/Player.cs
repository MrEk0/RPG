using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.AI;

public class Player : MonoBehaviour
{
    [SerializeField] CursorMapping[] cursorMapping = null;
    [SerializeField] float maxNavMeshDistance = 1f;
    [SerializeField] float maxPathDistance = 30f;

    //Fighter fighter;
    Mover mover;
    Health health;

    private void Awake()
    {
        health = GetComponent<Health>();
        //fighter = GetComponent<Fighter>();
        mover = GetComponent<Mover>();
    }

    void Update()
    {
        if (InteractWithUI())
        {
            SetCursor(Cursors.UI);
            return;
        }

        if (!health.IsAlive)
        {
            SetCursor(Cursors.None);
            return;
        }

        if (InteractWithRaycast())
            return;
        if (SetCursorToMove())
            return;
        SetCursor(Cursors.None);
    }

    private bool InteractWithUI()
    {
        return EventSystem.current.IsPointerOverGameObject();//is it over a gameobject that is a piece of UI
    }

    private bool InteractWithRaycast()
    {
        RaycastHit[] raycastHits = SortAllRaycast();
        foreach(RaycastHit hit in raycastHits)
        {
            IRaycastable[] raycasts=hit.transform.GetComponents<IRaycastable>();
            foreach (IRaycastable raycast in raycasts)
            {
                if(raycast.HandleRaycast(this))
                {
                    SetCursor(raycast.GetCursors());
                    return true;
                }
            }
        }
        return false;
    }

    private RaycastHit[] SortAllRaycast()
    {
        RaycastHit[] hits = Physics.RaycastAll(GetRay());
        float[] distances = new float[hits.Length];
        for (int i= 0; i<distances.Length; i++)
        {
            distances[i] = hits[i].distance;
        }
        Array.Sort(distances, hits);
        return hits;
    }

    private bool SetCursorToMove()
    {
        //RaycastHit hit;
        Vector3 target;
        bool hasHit = RaycastNavMesh(out target);
        if (hasHit)
        {
            if (Input.GetMouseButton(0))
            {
                mover.StartMovement(target, 1f);
            }
            SetCursor(Cursors.Move);
            return true;
        }
        return false;
    }

    private bool RaycastNavMesh(out Vector3 target)//to avoid movement aside notwalkable surface;
    {
        target = new Vector3();

        NavMeshHit meshHit;
        RaycastHit hit;

        bool hasHit = Physics.Raycast(GetRay(), out hit);
        //look for the nearest navmesh position
        bool hasCastToNavMesh =NavMesh.SamplePosition(hit.point, out meshHit, maxNavMeshDistance, NavMesh.AllAreas);                             
        if (!hasCastToNavMesh)
            return false;

        target = meshHit.position;

        NavMeshPath path = new NavMeshPath();////a list of waypoints stored in the corners array
        bool hasPath=NavMesh.CalculatePath(transform.position, target, NavMesh.AllAreas, path);
        if (!hasPath)
            return false;
        if (path.status != NavMeshPathStatus.PathComplete)
            return false; // to avoid a possible movement to a "walkable" position which is not achievable
        if (GetLengthPath(path) > maxPathDistance)
            return false;

        return true;
    }

    private float GetLengthPath(NavMeshPath path)//the full distance to the target
    {
        float pathDistance = 0f;

        if (path.corners.Length < 2)
            return pathDistance;
        for (int i = 0; i < path.corners.Length - 1; i++)
        {
            pathDistance += Vector3.Distance(path.corners[i], path.corners[i + 1]);
        }
        return pathDistance;
    }

    private void SetCursor(Cursors cursor)
    {
        CursorMapping cursorMapping = GetCursorMapping(cursor);
        Cursor.SetCursor(cursorMapping.texture, Vector2.zero, CursorMode.Auto);
    }

    private CursorMapping GetCursorMapping(Cursors cursor)
    {
        foreach (CursorMapping cursorMap in cursorMapping)
        {
            if (cursorMap.type == cursor)
            {
                return cursorMap;
            }
        }
        return cursorMapping[0];
    }

    private Ray GetRay()
    {
        return Camera.main.ScreenPointToRay(Input.mousePosition);
    }

    [System.Serializable]
    class CursorMapping
    {
        public Cursors type;
        public Texture2D texture;
    }
}
