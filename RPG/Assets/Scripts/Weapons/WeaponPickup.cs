using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour, IRaycastable
{
    [SerializeField] WeaponConfig weapon;
    [SerializeField] float hideTime = 3f;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Pickup(collider.GetComponent<Fighter>());
        }
    }

    private void Pickup(Fighter fighter)
    {
        fighter.EquipWeapon(weapon);
        StartCoroutine(HideAndShow(hideTime));
    }

    IEnumerator HideAndShow(float hideTime)
    {
        HidePickup();
        yield return new WaitForSeconds(hideTime);
        ShowPickup();
    }

    private void HidePickup()
    {
        GetComponent<Collider>().enabled = false;
        foreach(Transform child in transform)
        {
            child.gameObject.SetActive(false);
        }
    }

    private void ShowPickup()
    {
        GetComponent<Collider>().enabled = true;
        foreach (Transform child in transform)
        {
            child.gameObject.SetActive(true);
        }
    }

    public bool HandleRaycast(Player player)
    {
        if(Input.GetMouseButtonDown(0))
        {
            Pickup(player.GetComponent<Fighter>());//to pick up immediately before getting closer;
        }
        return true;
    }

    public Cursors GetCursors()
    {
        return Cursors.Weapon;
    }
}
