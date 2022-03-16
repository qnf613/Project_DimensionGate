using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponEquipped {yes, no};
public class Weapon : MonoBehaviour
{
    [SerializeField] protected float CritMod;
    [SerializeField] protected float CritDamageMod = 2;
    [SerializeField] protected float GlobalCritRate;
    protected string wName;
    protected string wDescription;
    [SerializeField]protected float damage;
    protected float wAtkspeed;
    protected float wRange;
    protected int enhancement;
    protected int maxEnhance;
    public WeaponEquipped we;
    public float finalDamageNumber;
    protected float lastShot = 0f;
    protected Vector3 targetPosition;
    [SerializeField]protected Camera cam;
    [SerializeField]protected GameObject projectile;

    protected bool crit;
    protected Weapon()
    {
        
        wName = "";
        wDescription = "";
        wAtkspeed = 0;
        wRange = 0;
        enhancement = 1;
        we = WeaponEquipped.yes;
        CritMod = 2;
        
    }
    protected void Start()
    {
        cam = Camera.main;
    }
    
    // Update is called once per frame
    protected virtual void Update()
    {
        switch (we)
        {
            case WeaponEquipped.yes:
                CheckCamera();
                Aim();
                Shoot();
                break;
            case WeaponEquipped.no:
                break;
            default:
                break;
        }
    }
    void CheckCamera()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }
   
    protected virtual void Aim()
    {
        
    }
    protected virtual void Shoot()
    {
        CheckIfCrit();
        Instantiate(projectile, transform.position, transform.rotation);
        projectile.GetComponent<StraightProjectile>();
        projectile.GetComponent<DealDamage>().SetDamage(CalcFinalDamage(), crit, CritDamageMod);
    }

    public void Enhance()
    {
        Debug.Log("Enhanced!");
        if (enhancement < maxEnhance)
        {
            enhancement++;
        }
        enhancement ++;
    }

    protected virtual void IncreaseStats()
    {

    }
    protected virtual void CheckIfCrit()
    {
        crit = this.gameObject.GetComponent<CheckForCrits>().CheckCrits(GlobalCritRate, CritMod);
    }
    protected virtual float CalcFinalDamage()
    {
        if (crit == true)
        {
            finalDamageNumber = this.gameObject.GetComponent<Refine>().ChangeDamageBasedOnRefine(damage) * CritDamageMod; 
        }
        else if (crit == false)
        {
            finalDamageNumber = this.gameObject.GetComponent<Refine>().ChangeDamageBasedOnRefine(damage);
        }
        return finalDamageNumber;
    }
}
