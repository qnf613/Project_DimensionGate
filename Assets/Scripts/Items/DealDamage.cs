using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamage : MonoBehaviour
{
    public float damage = 20;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageSystem>() == null) { }
        else
        collision.gameObject.GetComponent<DamageSystem>().TakeDamage(damage);
    }
}
