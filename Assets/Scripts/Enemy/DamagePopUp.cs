using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DamagePopUp : MonoBehaviour
{

    [SerializeField] private float speed = .3f;
    float dmg; //damage
    bool c; // crit
    float timer = 1;
    GameObject OffSet;
    GameObject pfDamagePopup;
    // Start is called before the first frame update
   
    public void SetValues(float damage, bool crit, GameObject _Offset)
    {
        dmg = damage;
        c = crit;
        OffSet = _Offset;
        pfDamagePopup = this.gameObject;
        SetNumber(dmg, DamageColor(c), SetFont(dmg));
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.up * speed * Time.deltaTime;
    }
    public void SetNumber(float damage, Color c, float fontsize)
    {
        var tmp = pfDamagePopup.GetComponent<TextMeshPro>();
        tmp.text = ((int)damage).ToString();
        tmp.fontSize = fontsize;
        tmp.color = c;
    }
   
    float SetFont(float dmg)
    {
        float fontsize = 32;
        fontsize += dmg * .5f;
        if (fontsize > 60)
        {
            fontsize = 60;
        }
        return fontsize;
        //Debug.Log(DamageIndicator.fontSize);
    }

    Color DamageColor(bool crit)
    {
        Color color = Color.white;
        if (crit == true)
        {
            color = Color.red;
        }
        else if (crit == false)
        {
            color = Color.white;
        }
        return color;

        //Invoke("ClearDamageUI", .5f);
    }
}
