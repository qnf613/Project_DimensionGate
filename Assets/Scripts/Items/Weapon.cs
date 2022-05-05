using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponEquipped {yes, no};
public class Weapon : MonoBehaviour
{
    public float CritMod;
    public float CritDamageMod = 2;
    public float GlobalCritRate;
    protected string wName;
    protected string wDescription;
    public float damage;
    protected float wAtkspeed;
    protected float wRange;
    public int enhancement;
    protected int maxEnhance = 10;
    public WeaponEquipped we;
    public float finalDamageNumber;
    protected float lastShot = 0f;
    protected Vector3 targetPosition;
    [SerializeField]protected Camera cam;
    [SerializeField]protected GameObject projectile;
    [SerializeField]protected bool crit;
    [SerializeField]protected AudioClip weaponSound;
    [SerializeField]protected float volume = 0.50f;



    public bool RefineCritChance, RefineCritDamage, refineDamage; //these bools will be in the list above to identify which refinement type they will follow

   

    protected Weapon()
    {
       
        wName = "";
        wDescription = "";
        wAtkspeed = 0;
        wRange = 0;
        enhancement = 0;
        we = WeaponEquipped.yes;
        GlobalCritRate = 10;

        //add the refinement types to the list.
        
        
    }
    protected void Start()
    {
        cam = Camera.main;
        
    }
    private void Awake()
    {
        GlobalCritRate = 10;
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
        AudioSource.PlayClipAtPoint(weaponSound, transform.position, volume);
        Instantiate(projectile, transform.position, transform.rotation);
        projectile.GetComponent<StraightProjectile>();
        projectile.GetComponent<DealDamage>().SetDamage(CalcCritDamage(), crit, CritDamageMod);
    }

    public void Enhance()
    {
       
        if (enhancement < maxEnhance)
        {
            Debug.Log("Enhanced!");
            enhancement++;
            this.gameObject.GetComponent<Refine>().SetRefine(enhancement);
            ApplyEnhancement();
        }
        
    }
    protected virtual void ApplyEnhancement()
    {
        this.gameObject.GetComponent<Refine>().findRefineType(refineDamage, RefineCritChance, RefineCritDamage, damage);
    }

    protected virtual void IncreaseStats()
    {

    }
    public virtual void CheckIfCrit()
    {
        crit = this.gameObject.GetComponent<CheckForCrits>().CheckCrits(GlobalCritRate, CritMod);
    }
    public virtual float CalcCritDamage()
    {
        if (crit == true)
        {
            finalDamageNumber = damage * CritDamageMod; 
        }
        else if (crit == false)
        {
            finalDamageNumber = damage;
        }
        return finalDamageNumber;
    }
}
