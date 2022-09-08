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
    public float bleedStrength;
    public float bleedDuration;
    private float bs; //bleedstrength modifier

    public GameObject UpgradedProjectile;
    // Start is called before the first frame update
    void Start()
    {
        // Overriding the basic stats and info about the weapon here
        this.wName = name;
        this.wDescription = description;
        this.wRange = rage;
        this.wAtkspeed = attackspeed;
        we = WeaponEquipped.yes;
        bs = 3f;
        bleedDuration = 3;
    }

    protected override void Update()
    {
        base.Update();

        bleedStrength = damage/bs;
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
           
            foreach (DealDamage item in projectile.GetComponentsInChildren<DealDamage>())
            {
                item.SetDamage(CalcCritDamage(), crit, CritDamageMod);
            }
            foreach (ApplyDebuff item in projectile.GetComponentsInChildren<ApplyDebuff>())
            {
                
                item.SetDebuffStrenghtDuration(bleedStrength, bleedDuration, 2);
            }

            lastShot = Time.time;
        }
    }
    public override void specialRefines()
    {
        if (this.enhancement == 3)
        {
            bs = 1.5f;
        }
        if (this.enhancement == 6)
        {
            this.projectile = UpgradedProjectile; 
        }
        if (this.enhancement == 9)
        {
            this.bleedDuration *= 2;
        }
    }
}
