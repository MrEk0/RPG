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
        UI
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
            
        if (AttackEnemy())
            return;
        if (SetCursorToMove())
            return;
        SetCursor(Cursors.None);
    }

    private bool InteractWithUI()
    {
        //if (EventSystem.current.IsPointerOverGameObject())
        return EventSystem.current.IsPointerOverGameObject();//is it over a gameobject that is a piece of UI
        //{
        //    SetCursor(Cursors.UI);
        //    return true;
        //}
        //return false;
    }

    private bool AttackEnemy()
    {
        RaycastHit[] hits = Physics.RaycastAll(GetRay());
        foreach (RaycastHit hit in hits)
        {
            Enemy enemy = hit.transform.GetComponent<Enemy>();
            if (enemy == null) continue;

            if (fighter.CanAttack(enemy.gameObject))
            {
                if (Input.GetMouseButton(0))
                {
                    enemy.Attack();
                    fighter.AttackTheTarget(enemy.gameObject);
                }
                SetCursor(Cursors.Attack);
                return true;
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
