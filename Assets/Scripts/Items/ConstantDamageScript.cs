using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantDamageScript : Weapon
{
    [SerializeField] private float atkspeed = 0.5f;
    [SerializeField] private float lasthit;
    [SerializeField] private float duration;
    [SerializeField] private float attackDamage = 10;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<DamageSystem>() == null) { }
        else
        {
            if (Time.time > atkspeed + lasthit)
            {
                other.gameObject.GetComponent<DamageSystem>().TakeDamage(attackDamage, false);
                lasthit = Time.time;
            }

        }
    }
    
    private void Start()
    {
        //The pool should only last a few seconds
        Destroy(this.gameObject, duration);
    }
}
