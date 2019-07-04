using UnityEngine;

[CreateAssetMenu(fileName ="Weapon", menuName ="Weapons/Create a new Weapon", order =0)]
public class Weapon:ScriptableObject
{
    [SerializeField] AnimatorOverrideController animatorOverrideController = null;
    [SerializeField] GameObject weaponPrefab = null;//if we don't have a weapon
    [SerializeField] float attackRange = 2f;
    [SerializeField] int damage = 10;
    [SerializeField] bool isRightHand = true;

    Transform handPosition;
   

    public void Spawner(Transform rightHand, Transform leftHand, Animator animator)
    {
        if(weaponPrefab!=null)
        {
            if (isRightHand)
                handPosition = rightHand;
            else
                handPosition = leftHand;

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
