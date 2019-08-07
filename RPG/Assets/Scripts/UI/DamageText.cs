using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

//namespace Assets.Scripts.UI
//{
class DamageText : MonoBehaviour
{
    Text damageText;
    private void Awake()
    {
        damageText = GetComponentInChildren<Text>();
    }

    public void Text(float damage)
    {
        damageText.text = damage.ToString();
    }
}
//}
