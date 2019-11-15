using System;
using UnityEngine;

[CreateAssetMenu(fileName ="Weapon", menuName ="Weapons/Create a new Weapon", order =0)]
public class WeaponConfig:ScriptableObject
{
    [SerializeField] AnimatorOverrideController animatorOverrideController = null;
    [SerializeField] Weapon weaponPrefab = null;//if we don't have a weapon
    [SerializeField] float attackRange = 2f;
    [SerializeField] int damage = 10;
    [SerializeField] bool isRightHand = true;
    [SerializeField] GameObject projectilePrefab = null;

    Transform handPosition;

    const string weaponName = "Weapon";

    public void Spawner(Transform rightHand, Transform leftHand, Animator animator)
    {
        DestroyOldWeapon(rightHand, leftHand);

        if(weaponPrefab!=null)
        {
            handPosition = GetHandPosition(rightHand, leftHand);

            Weapon weapon=Instantiate(weaponPrefab, handPosition);
            weapon.gameObject.name = weaponName;
        }

        var overrideController = animator.runtimeAnimatorController as AnimatorOverrideController;//RuntimeAnimatorController if it's not null
        if (animatorOverrideController != null)
        {
            animator.runtimeAnimatorController = animatorOverrideController;
            //animator.runtimeAnimatorController = animatorOverrideController.runtimeAnimatorController;
        }
        else if (overrideController != null)
        {
            animator.runtimeAnimatorController = overrideController.runtimeAnimatorController;//find parent and put in the runtime animator
                                                                                              //in case of overridden
        }
    }

    private void DestroyOldWeapon(Transform rightHand, Transform leftHand)
    {
       Transform oldWeapon = rightHand.Find(weaponName);
        if (oldWeapon == null)
        {
            oldWeapon = leftHand.Find(weaponName);
        }

        if(oldWeapon==null)
        {
            return;
        }
        oldWeapon.name = "Destroyed";
        Destroy(oldWeapon.gameObject);
    }

    private Transform GetHandPosition(Transform rightHand, Transform leftHand)
    {
        if (isRightHand)
            handPosition = rightHand;
        else
            handPosition = leftHand;
        return handPosition;
    }

    public void LaunchTheProjectile(GameObject initiator, Transform rightHand, Transform leftHand, Health target, float levelDamage)
    {
        if (projectilePrefab == null) return;

        GameObject projectile = Instantiate(projectilePrefab, GetHandPosition(rightHand, leftHand).position, Quaternion.identity);
        projectile.GetComponent<Projectile>().targetInstall(initiator, target, levelDamage);
        projectile.GetComponent<Projectile>().goalForProjectile();
    }

    public bool isHasProjectile()
    {
        return projectilePrefab;
    }

    public float GetRange()
    {
        return attackRange;
    }

    public int GetDamage()
    {
        return damage;
    }
}
