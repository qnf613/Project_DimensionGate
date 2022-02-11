    using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonFlask : Weapon
{
   
    [SerializeField]
    private GameObject poisonFlaskPrefab;
    protected Vector3 projectileDirection;


    void Start()
    {
        // Overriding the basic stats and info about the weapon here
        this.name = "Venom Flask";
        this.description = "Throw a flask which leaves a pool of poison on the ground.";
        this.damage = 10;
        this.range = 20;
        this.atkspeed = 0.7f;
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
        if (Time.time > atkspeed + lastShot)
        {
            projectileDirection = (this.transform.position - targetPosition);

            //TODO : Change this to match player Rotation and position

            Instantiate(poisonFlaskPrefab, transform.position, transform.rotation);
            poisonFlaskPrefab.GetComponent<StraightProjectile>();

            lastShot = Time.time;


        }

    }
}
