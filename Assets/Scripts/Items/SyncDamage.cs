using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyncDamage : MonoBehaviour
{

    [SerializeField] private GameObject weapon;
    private float damage;
    private float currentDamage;
    // Start is called before the first frame update
    void Start()
    {
        currentDamage = weapon.GetComponent<Weapon>().damage;
        damage = this.gameObject.GetComponent<DealDamage>().damage;
        if (damage == currentDamage) { }
        else
        {
            DamageSync(damage);
            Debug.Log("Damage isn't equal");
        }
    }

    private void DamageSync(float damage)
    {
        Debug.Log("Damage synced");
        currentDamage = this.gameObject.GetComponent<DealDamage>().damage;
        Debug.Log("current damage is:" + currentDamage + "old damage was" + damage);
    }

}
