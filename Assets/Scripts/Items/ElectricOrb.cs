using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricOrb : Weapon
{
    [SerializeField] private string name = "Electric Orb";
    [SerializeField] private string description = "Shock and Awe your enemies!";
    [SerializeField] private int range = 20;
    [SerializeField] private float attackspeed = .7f;

    [SerializeField] private int pierceCount;
    [SerializeField] private int maxPierceCount;
    protected Vector3 projectileDirection;


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
        float rotz = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg -90f;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);

    }
    protected override void Shoot()
    {

        //This weapon shoots a projectile forward
        if (Time.time > attackspeed + lastShot)
        {
            CheckIfCrit();
            base.Shoot();
            projectileDirection = (this.transform.position - targetPosition);

            lastShot = Time.time;
        }

    }

}

