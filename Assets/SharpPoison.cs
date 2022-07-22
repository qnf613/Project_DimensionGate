using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharpPoison : PoisonFlask
{
    

    [SerializeField] private float sharpDamage;
    public GameObject Spikes;
    void Start()
    {
        // Overriding the basic stats and info about the weapon here
        this.wName = name;
        this.wDescription = description;
        this.wRange = rage;
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

        //This weapon shoots a projectile forward
        if (Time.time > wAtkspeed + lastShot)
        {
            AudioSource.PlayClipAtPoint(weaponSound, transform.position, volume);
            Instantiate(projectile, transform.position, transform.rotation);
            projectile.GetComponent<StraightProjectile>();

            projectileDirection = (this.transform.position - targetPosition);

            //TODO : Change this to match player Rotation and position

            lastShot = Time.time;


        }

    }
    protected override void ApplyEnhancement()
    {
        base.ApplyEnhancement();
        damage = damage;
    }
    public float CalcCritDamageForSpikes()
    {
        if (crit == true)
        {
            finalDamageNumber = sharpDamage * CritDamageMod;
        }
        else if (crit == false)
        {
            finalDamageNumber = sharpDamage;
        }
        return finalDamageNumber;
    }
   
}
