using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyCometDealDamage : LuckyComet
{
    public bool CRIT;
    private float _dmg;
    [SerializeField] protected float critMod;
    [SerializeField] protected float critDamageMod = 2;
    [SerializeField] protected float globalCritRate;
    private void Start()
    {
        this.critDamageMod = CritDamageMod;
        this.globalCritRate = GlobalCritRate;
        this.critMod = CritMod;

    }
    public void SetDamage(float dmg, bool crit, float critDamage)
    {
        CRIT = crit;
        if (crit == true)
        {
            _dmg = dmg;
        }
        else
        {
            _dmg = dmg;
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageSystem>() == null) { }
        else
        {

            CheckIfCrit();
            SetDamage(CalcCritDamage(), crit, CritDamageMod);
            collision.gameObject.GetComponent<DamageSystem>().TakeDamage(_dmg, CRIT);
            AudioSource.PlayClipAtPoint(weaponSound, transform.position, volume);
        }
        }
}
