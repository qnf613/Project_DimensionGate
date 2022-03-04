using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sharpshooter : Weapon
{
    [SerializeField] private string name = "Sharpshooter";
    [SerializeField] private string description = "Fires high-speed shot that pierces through enemies.";
    [SerializeField] private float damage = 100;
    [SerializeField] private int rage = 20;
    [SerializeField] private float attackspeed = .09f;
    [SerializeField] private GameObject sharpshooterPrefab;
    [SerializeField] private int pierceCount;
    [SerializeField] private int maxPierceCount;
    protected Vector3 projectileDirection;

    // Start is called before the first frame update
    void Start()
    {
        // Overriding the basic stats and info about the weapon here
        this.wName = name;
        this.wDescription = description;
        this.wDamage = damage;
        this.wRange = rage;
        this.wAtkspeed = attackspeed;
        we = WeaponEquipped.no;

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
            projectileDirection = (this.transform.position - targetPosition);

            //TODO : Change this to match player Rotation and position
            /*
             * Summary
             * When you instantiate the projectile, Im going into the projectile script to change the damage it does.
             * 
             * To calculate the damage, Im sending the baase damage of the weapon over to the refine script, finding the new value and 
             * setting it as the final damage value.
            */
            Instantiate(sharpshooterPrefab, transform.position, transform.rotation);
            sharpshooterPrefab.GetComponent<StraightProjectile>();
            finalDamageNumber = this.gameObject.GetComponent<Refine>().ChangeDamageBasedOnRefine(damage);
            sharpshooterPrefab.GetComponent<DealDamage>().SetDamage(finalDamageNumber);
            lastShot = Time.time;
        }

    }
}
