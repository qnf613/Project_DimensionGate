using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonFlask : Weapon
{
    
    [SerializeField] protected string name = "Venom Flask";
    [SerializeField] protected string description = "Throw a flask which leaves a pool of poison on the ground.";
    [SerializeField] protected int rage = 20;
    [SerializeField] protected float attackspeed = .7f;
    [SerializeField] protected GameObject poisonFlaskPrefab;
    public float dotDamageScale = 1.1f;

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
     
    }
}
