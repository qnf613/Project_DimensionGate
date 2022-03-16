using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public bool CRIT;
    [SerializeField]private float damage;
    public virtual void SetDamage(float dmg, bool crit, float critDamage) 
    {
        CRIT = crit;
        if (crit == true)
        {
            damage = dmg;
        }
        else
        {
            damage = dmg;
        }
    
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageSystem>() == null) { }
        else
        collision.gameObject.GetComponent<DamageSystem>().TakeDamage(damage, CRIT);
    }
}
