using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeLauncher : Weapon
{
    [SerializeField] private string name = "Grenade Launcher";
    [SerializeField] private string description = "Fire an exploding grenade!";
    [SerializeField] private int rage = 20;
    [SerializeField] private float attackspeed = 3f;
    protected Vector3 projectileDirection;


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
            
            CheckIfCrit();
            AudioSource.PlayClipAtPoint(weaponSound, transform.position, volume);
            Instantiate(projectile, transform.position, transform.rotation);
            projectile.GetComponent<StraightProjectile>();

            projectileDirection = (this.transform.position - targetPosition);

            //TODO : Change this to match player Rotation and position
            /*
             * Summary
             * When you instantiate the projectile, Im going into the projectile script to change the damage it does.
             * 
             * To calculate the damage, Im sending the baase damage of the weapon over to the refine script, finding the new value and 
             * setting it as the final damage value.
            */



            //This will make the damage of the explosion scale with refine.
            //This will also make the damage of the explosion 1/2 of the damage of the collision.
            projectile.GetComponent<Explode>().GetExplosionDamage(CalcCritDamage(), crit, CritDamageMod);
            lastShot = Time.time;
        }
    }
    public override float CalcCritDamage()
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
