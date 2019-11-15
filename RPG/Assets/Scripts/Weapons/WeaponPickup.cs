using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour, IRaycastable
{
    [SerializeField] WeaponConfig weapon;
    [SerializeField] float hideTime = 3f;
    [SerializeField] float pointsToHeal = 20f;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            Pickup(collider.gameObject);
        }
    }

    private void Pickup(GameObject character)
    {
        if (weapon != null)
        {
            character.GetComponent<Fighter>().EquipWeapon(weapon);
        }

        if (pointsToHeal > 0)
        {
            character.GetComponent<Health>().Heal(pointsToHeal);
        }

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
            Pickup(player.gameObject);//to pick up immediately before getting closer;
        }
        return true;
    }

    public Cursors GetCursors()
    {
        return Cursors.Weapon;
    }
}
