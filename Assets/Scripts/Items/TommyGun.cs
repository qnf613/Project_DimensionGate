using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TommyGun : Weapon
{
    [SerializeField] private string name = "Gatling";
    [SerializeField] private string description = "Extreme rapid-fire!";
    [SerializeField] private int range = 20;
    [SerializeField] private float attackspeed = .3f;
    [SerializeField] private int pierceCount;
    [SerializeField] private int maxPierceCount;
    [SerializeField] private float ammo;
    [SerializeField] private float maxammo;
    [SerializeField] private float reloadTime = 3f;
    protected Vector3 projectileDirection;
    int count;
    bool infiniteAmmo = false;
    void Start()
    {
        // Overriding the basic stats and info about the weapon here
        this.wName = name;
        this.wDescription = description;
        this.wRange = range;
        this.wAtkspeed = attackspeed;
        we = WeaponEquipped.yes;
    }
    protected override void Aim()
    {
        targetPosition = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        //if any changes to how weapon aims, change here
        //base.Aim();
    }
    protected override void Shoot()
    {
        if (Time.time > wAtkspeed + lastShot)
        {
            if (ammo > 0 && infiniteAmmo == false)
            {
                count++;   
                ammo--;
               // Debug.Log(count);
                base.Shoot();
                projectileDirection = (this.transform.position - targetPosition);
                
                lastShot = Time.time;
            }
            if (infiniteAmmo == true)
            {
                if (Time.time > wAtkspeed + lastShot)
                {
                    if (weaponSound != null)
                    {
                       // AudioSource.PlayClipAtPoint(weaponSound, transform.position, volume);
                    }

                    CheckIfCrit();
                    //AudioSource.PlayClipAtPoint(weaponSound, transform.position, volume);
                    if (projectile != null)
                    {
                        Instantiate(projectile, transform.position, transform.rotation);
                    }
                    projectile.GetComponentInChildren<StraightProjectile>();
                    projectile.GetComponent<DealDamage>().SetDamage(CalcCritDamage(), crit, CritDamageMod);
                    lastShot = Time.time;
                }
                projectileDirection = (this.transform.position - targetPosition);

                lastShot = Time.time;
            }
            
            //Debug.Log("ammo is: " + ammo);
        }
        else if (ammo == 0 && infiniteAmmo == false)
        {
            Invoke("Reload", reloadTime);
        }
    }
    private void Reload()
    {      
          //Debug.Log("reloaded!");
           ammo = maxammo;
    }
    public override void specialRefines()
    {
        if (enhancement == 3)
        {//double ammo / +20% crit rate
            this.maxammo *= 2;
            this.CritMod += 20;
        }
        if (enhancement == 6)
        { // half reload speed, +3 maximum pierce
            projectile.GetComponent<PierceCheckScript>().maxPierceCount = 3;
            reloadTime /= 2;
        }
        if (enhancement < 6)
        {
            projectile.GetComponent<PierceCheckScript>().maxPierceCount = 1;
        }
        if (enhancement == 9)
        { // +50% Atkspeed / +30% crit damage / +20% crit chance / Infinite Ammo
            this.wAtkspeed *= .5f;
            this.CritDamageMod *= 1.3f;
            this.CritMod += 20f;
        }
        if (enhancement >= 9)
        {
            infiniteAmmo = true;
        }
        
    }
    protected override void Update()
    {
        if (enhancement < 9) { infiniteAmmo = false; }
        if (enhancement < 6) { projectile.GetComponent<PierceCheckScript>().maxPierceCount = 1; }
        base.Update();
    }
}
