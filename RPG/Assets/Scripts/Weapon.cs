using UnityEngine;

[CreateAssetMenu(fileName ="Weapon", menuName ="Weapons/Create a new Weapon", order =0)]
public class Weapon:ScriptableObject
{
    [SerializeField] AnimatorOverrideController animatorOverrideController = null;
    [SerializeField] GameObject weaponPrefab = null;//if we don't have a weapon
    [SerializeField] float attackRange = 2f;
    [SerializeField] int damage = 10;

    public void Spawner(Transform handPosition, Animator animator)
    {
        if(weaponPrefab!=null)
        {
            Instantiate(weaponPrefab, handPosition);
        }
        if (animatorOverrideController != null)
        {
            animator.runtimeAnimatorController = animatorOverrideController;
        }
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
