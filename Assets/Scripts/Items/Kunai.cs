using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kunai : Weapon
{
    [SerializeField] private string name = "Kunai";
    [SerializeField] private string description = "Slow enemies down";
    [SerializeField] private int rage = 20;
    [SerializeField] private float attackspeed = .09f;

    [SerializeField] private int pierceCount;
    [SerializeField] private int maxPierceCount;
    protected Vector3 projectileDirection;
    public float slowStrength;
    public float slowDuration;

    // Start is called before the first frame update
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

            foreach (ApplyDebuff item in projectile.GetComponentsInChildren<ApplyDebuff>())
            {
                slowStrength = damage / 3;
                item.SetDebuffStrenghtDuration(slowStrength, slowDuration, 1);
            }

            lastShot = Time.time;
        }
    }
}
