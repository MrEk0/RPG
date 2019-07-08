using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickup : MonoBehaviour
{
    [SerializeField] Weapon weapon;
    [SerializeField] float hideTime = 3f;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.CompareTag("Player"))
        {
            collider.GetComponent<Fighter>().EquipWeapon(weapon);
            //Destroy(gameObject);
            StartCoroutine(HideAndShow(hideTime));
        }
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
}
