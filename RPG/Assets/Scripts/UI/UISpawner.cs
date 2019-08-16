using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

//namespace Assets.Scripts.UI
//{
class UISpawner : MonoBehaviour
{
    [SerializeField] GameObject damageCanvas;////

    public void Spawn(float damage)
    {
        GameObject damageUI = Instantiate(damageCanvas, transform);
        damageUI.GetComponent<DamageText>().Text(damage);
        //Destroy(damageUI, 2f);
    }
}
//}
