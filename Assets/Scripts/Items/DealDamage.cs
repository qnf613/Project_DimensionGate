using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    [SerializeField]private float damage;
    public void SetDamage(float dmg) 
    { 
    damage = dmg;
        Debug.Log("Damage changed to "+ dmg);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageSystem>() == null) { }
        else
        collision.gameObject.GetComponent<DamageSystem>().TakeDamage(damage);
    }
}
