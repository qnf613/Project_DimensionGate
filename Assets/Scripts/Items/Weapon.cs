using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponEquipped {yes, no};
public class Weapon : Items
{
    public float CritMod;
    public float CritDamageMod = 2;
    public float GlobalCritRate;

    protected string wName;
    public string wDescription;
    public string descrptionTest = "";
    public float damage;
    public float wAtkspeed;
    protected float wRange;
    //public int enhancement;
    //protected int maxEnhance = 10;
    public WeaponEquipped we;
    public float finalDamageNumber;
    protected float lastShot = 0f;
    protected Vector3 targetPosition;
    [SerializeField]protected Camera cam;
    public GameObject projectile;
    [SerializeField]public bool crit;
    public AudioClip weaponSound;
    public float volume = 0.50f;

    public DPSMeter dpsm;
    public float dps, cr;
    bool upgrade = false;

    public bool RefineCritChance, RefineCritDamage, refineDamage; //these bools will be in the list above to identify which refinement type they will follow

    [SerializeField] protected PlayerStats _Stats;
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
        //Get Component of player character's own stats
        if (_Stats == null)
        {
            _Stats = GameObject.Find("Player").GetComponent<PlayerStats>();
        }

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


        //Enhance cheat for debug purposes
            if (Input.GetKeyUp(KeyCode.G) == true)
            {
                this.Enhance();
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
        if (Time.time > wAtkspeed + lastShot)
        {
            if (weaponSound != null)
            {
                AudioSource.PlayClipAtPoint(weaponSound, transform.position, volume);
            }

            CheckIfCrit();
            AudioSource.PlayClipAtPoint(weaponSound, transform.position, volume);
            if (projectile != null)
            {
                Instantiate(projectile, transform.position, transform.rotation);
            }
            projectile.GetComponentInChildren<StraightProjectile>();
            projectile.GetComponent<DealDamage>().SetDamage(CalcCritDamage(), crit, CritDamageMod);
            lastShot = Time.time;
        }
    }

    public override void Enhance()
    {
       
        if (enhancement < maxEnhance)
        {
            Debug.Log("Enhanced!");
            enhancement++;
            this.gameObject.GetComponent<Refine>().SetRefine(enhancement);
            ApplyEnhancement();
            specialRefines();
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
        crit = this.gameObject.GetComponent<CheckForCrits>().CheckCrits(GlobalCritRate, CritMod + _Stats.BaseCritRate);
    }
    public virtual float CalcCritDamage()
    {
        if (crit == true)
        {
            finalDamageNumber = (damage * _Stats.BaseDMG) * (CritDamageMod + _Stats.BaseCritDMG); 
        }
        else if (crit == false)
        {
            finalDamageNumber = damage * _Stats.BaseDMG;
        }
        return finalDamageNumber;
    }
    public virtual void specialRefines()
    { 
    }
}
