using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicArrow : Weapon
{
    [SerializeField] private string name = "Magic Arrow";
    [SerializeField] private string description = "Shoot an arrow which pierces through enemies";
    [SerializeField] private int rage = 20;
    [SerializeField] private float attackspeed = .7f;
    
    [SerializeField] private int pierceCount;
    [SerializeField] private int maxPierceCount;
    protected Vector3 projectileDirection;
    
    
    void Start()
    {
        // Overriding the basic stats and info about the weapon here
        this.wName = name;
        this.wDescription = description;
        this.wRange = rage;
        this.wAtkspeed = attackspeed;
        we = WeaponEquipped.yes;
        this.descrptionTest = description;
    }

    
    protected override void Aim()
    {
        targetPosition = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg -90f;
        transform.rotation = Quaternion.Euler(0f,0f, rotz);
        //if any changes to how weapon aims, change here
        //base.Aim();
    }
    protected override void Shoot()
    {
        
        //This weapon shoots a projectile forward
        if (Time.time > attackspeed + lastShot)
        {
            base.Shoot();
            projectileDirection = (this.transform.position - targetPosition);
            
            //TODO : Change this to match player Rotation and position
            /*
             * Summary
             * When you instantiate the projectile, Im going into the projectile script to change the damage it does.
             * 
             * To calculate the damage, Im sending the baase damage of the weapon over to the refine script, finding the new value and 
             * setting it as the final damage value.
            */
            
            lastShot = Time.time;
        }

    }
    
    

}
