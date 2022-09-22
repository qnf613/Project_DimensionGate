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
    public GameObject UpgradedProjectile;
    public GameObject normalProjectile;
    void Start()
    {
        // Overriding the basic stats and info about the weapon here
        this.wName = name;
        this.wDescription = description;
        this.wRange = range;
        this.wAtkspeed = attackspeed;
        we = WeaponEquipped.yes;
    }

    protected override void Update()
    {
        if (enhancement < 9)
        {
            projectile.GetComponent<MultiplyProjectile>().spawnNewObject = normalProjectile;
        }
        base.Update();
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
    public override void specialRefines()
    { //+20% atk speed
        if (enhancement ==3)
        {
            this.wAtkspeed *= .8f;
            this.attackspeed *= .8f;
        }
        if (enhancement == 6)
        {//projectile will pierce one more target and multiply again.
            projectile.GetComponent<PierceCheckScript>().maxPierceCount += 1;
        }
        if (enhancement == 9)
        {//+20% crit chance, New projectile which multiplies into more energy balls, main projectile will now pierce more enemies
            this.CritMod *= 1.2f;
            projectile.GetComponent<MultiplyProjectile>().spawnNewObject = UpgradedProjectile;
            projectile.GetComponent<PierceCheckScript>().maxPierceCount += 3;
        }
        
    }
}

