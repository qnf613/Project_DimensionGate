using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Burstshot : Weapon
{
    [SerializeField] private string name = "Burstshot";
    [SerializeField] private string description = "Fires bullet bursts!";
    [SerializeField] private int range = 20;
    [SerializeField] private float attackspeed = .7f;
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
    protected override void Update()
    {
        if (enhancement < 6)
        {//projectiles now pierce one more enemy
            this.projectile.GetComponentInChildren<PierceCheckScript>().maxPierceCount = 1;
        }
        base.Update();
    }
    protected override void Shoot()
    {
        if (Time.time > wAtkspeed + lastShot)
        {
            CheckIfCrit();
            AudioSource.PlayClipAtPoint(weaponSound, transform.position, volume);
            if (projectile != null)
            {
                Instantiate(projectile, transform.position, transform.rotation);
            }
            projectile.GetComponent<StraightProjectile>();
            projectile.GetComponentInChildren<DealDamage>().SetDamage(CalcCritDamage(), crit, CritDamageMod);
            lastShot = Time.time;
        }
    }
    public override void specialRefines()
    {
        if (enhancement == 3)
        {//+30% atkspeed buff
            this.attackspeed *= .7f;
            this.wAtkspeed *= .7f;
        }
        if (enhancement == 6)
        {//projectiles now pierce one more enemy
            foreach (Transform i in projectile.transform)
            {
                i.gameObject.GetComponent<PierceCheckScript>().maxPierceCount =100;
            }
        }
        if (enhancement == 9)
        { //+60% crit damage
            this.CritDamageMod *= 1.6f;
        }
    }
}
