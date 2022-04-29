using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncDamage : MonoBehaviour
{
    [SerializeField] private GameObject weapon;
    private float damage;
    private float trueDamage;

    private void Awake()
    {
        trueDamage = weapon.GetComponent<DealDamage>().damage;
        damage = this.gameObject.GetComponent<DealDamage>().damage;

        if (damage == trueDamage) { }
        else
        {
            DamageSync();
        }
    }
    private void DamageSync()
    {
        Debug.Log("Damage synced");
        this.gameObject.GetComponent<DealDamage>().damage = trueDamage;

        if(weapon.GetComponent<DealDamage>().CRIT == true)
        {
          this.gameObject.GetComponent<DealDamage>().CRIT = true;
        }

        Debug.Log("current damage is:" + damage);
    }
}
