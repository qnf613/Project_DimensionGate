using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gatling : Weapon
{
    [SerializeField] private string name = "Gatling";
    [SerializeField] private string description = "Extreme rapid-fire!";
    [SerializeField] private int range = 20;
    [SerializeField] private float attackspeed = .3f;
    [SerializeField] private int pierceCount;
    [SerializeField] private int maxPierceCount;
    [SerializeField] private float ammo;
    [SerializeField] private float maxammo;
    [SerializeField] private float reloadTime = 3f;
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
        if (Time.time > wAtkspeed + lastShot && ammo > 0)
        {
            base.Shoot();
            projectileDirection = (this.transform.position - targetPosition);
            ammo--;
            lastShot = Time.time;
            //Debug.Log("ammo is: " + ammo);
        }
        else if (ammo == 0)
        {
            Invoke("Reload", reloadTime);
        }
    }
    private void Reload()
    {      
          //Debug.Log("reloaded!");
           ammo = maxammo;
    }    
}
