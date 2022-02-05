using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : Weapon
{
    [SerializeField] private GameObject SwordHitBox;
    protected Vector3 projectileDirection;
    // Start is called before the first frame update
    void Start()
    {
        this.name = "Giant F-ing Sword";
        this.description = "What else do you need to know, read the name...";
        this.damage = 60;
        this.atkspeed = 2f;
        we = WeaponEquipped.yes;;
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
            
            Instantiate(SwordHitBox, transform.position + targetPosition.normalized, transform.rotation);
            SwordHitBox.GetComponent<StraightProjectile>();
            
            lastShot = Time.time;
        }
    }
}
