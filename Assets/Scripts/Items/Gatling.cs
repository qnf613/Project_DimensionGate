using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatling : Weapon
{
    ///has a weird thing where the projectile gets stuck on the player sometimes, gonna fix that
  

    [SerializeField] private string name = "Gatling";
    [SerializeField] private string description = "Extreme rapid-fire!";
    [SerializeField] private int range = 20;
    [SerializeField] private float attackspeed = .3f;
    [SerializeField] private int pierceCount;
    [SerializeField] private int maxPierceCount;
    [SerializeField] private float rounds;
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
        float rotz = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
        //if any changes to how weapon aims, change here
        //base.Aim();
    }
    protected override void Shoot()
    {
        if (Time.time > wAtkspeed + lastShot)
        {
            base.Shoot();
            projectileDirection = (this.transform.position - targetPosition);
          
            lastShot = Time.time;
        }
    }

}
