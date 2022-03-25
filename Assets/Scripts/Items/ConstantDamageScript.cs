using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantDamageScript : MonoBehaviour
{
    [SerializeField] private float atkspeed = 0.5f;
    [SerializeField] private float lasthit;
    [SerializeField] private float duration;
    private float attackDamage;
    private GameObject VenomFlask;
    private float volume = 0.6f;
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
        VenomFlask = GameObject.Find("Venom Flask" + "(Clone)");
        attackDamage = VenomFlask.GetComponent<PoisonFlask>().dotDamage;
        //The pool should only last a few seconds
        Destroy(this.gameObject, duration);
    }
}
