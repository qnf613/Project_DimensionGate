using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicArrow : Weapon
{
    [SerializeField]
    private GameObject magicArrowProjectilePrefab; 
    protected Vector3 projectileDirection;
    
    void Start()
    {
        // Overriding the basic stats and info about the weapon here
        this.name = "Magic Arrow";
        this.description = "Shoot an arrow which pierces through enemies";
        this.damage = 10;
        this.range = 20;
        this.atkspeed = 0.7f;
        we = WeaponEquipped.yes;
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
        if (Time.time > atkspeed + lastShot)
        {
            projectileDirection = (this.transform.position - targetPosition);
            
            //TODO : Change this to match player Rotation and position
            
            Instantiate(magicArrowProjectilePrefab, transform.position, transform.rotation);
            magicArrowProjectilePrefab.GetComponent<Projectile>();
            
            lastShot = Time.time;
        }

    }

}
