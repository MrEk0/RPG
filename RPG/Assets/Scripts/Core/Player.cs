using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Player : MonoBehaviour
{
    [SerializeField] CursorMapping[] cursorMapping = null;

    Fighter fighter;
    Mover mover;
    Health health;

    enum Cursors
    {
        None,
        Attack,
        Move,
        UI,
        Weapon
    }

    private void Awake()
    {
        health = GetComponent<Health>();
        fighter = GetComponent<Fighter>();
        mover = GetComponent<Mover>();
    }

    void Update()
    {
        if(InteractWithUI())
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
        RaycastHit[] raycastHits = Physics.RaycastAll(GetRay());
        foreach(RaycastHit hit in raycastHits)
        {
            IRaycastable[] raycasts=hit.transform.GetComponents<IRaycastable>();
            foreach (IRaycastable raycast in raycasts)
            {
                if(raycast.HandleRaycast(this))
                {
                    SetCursor(Cursors.Weapon);
                    return true;
                }
            }
        }
        return false;
    }

    private bool SetCursorToMove()
    {
        RaycastHit hit;
        if (Physics.Raycast(GetRay(), out hit))
        {
            if (Input.GetMouseButton(0))
            {
                mover.StartMovement(hit.point, 1f);
            }
            SetCursor(Cursors.Move);
            return true;
        }
        return false;
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
        //public Vector2 hotSpot;
    }
}
