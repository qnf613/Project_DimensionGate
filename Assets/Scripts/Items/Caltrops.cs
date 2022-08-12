using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caltrops : Weapon
{
    [SerializeField] private string name = "Caltrops";
    [SerializeField] private string description = "Lay traps down for your enemies!";
    [SerializeField] private int range = 20;
    [SerializeField] private float attackspeed = 3f;
   
    [SerializeField] public float cooldown = 10f;
    private float timer = 1f;
    [SerializeField] public float attacktime = 2f;
    [SerializeField] public float attacktimelimit = 5;
    
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

    public float slowStrength;
    public float slowDuration;

    protected override void Aim()
    {
        targetPosition = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg - 90f;
        // change this for weapon spread
        float spread = Random.Range(-50, 50);
        transform.rotation = Quaternion.Euler(0f, 0f, rotz + spread);


        //if any changes to how weapon aims, change here
        //base.Aim();
    }
    protected override void Shoot()
    {

        // Attacks 
        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
        if (timer <= 0)
        {
            if (Time.time > wAtkspeed + lastShot)
            {

                CheckIfCrit();
                base.Shoot();
                projectileDirection = (this.transform.position - targetPosition);

                projectile.GetComponent<StraightProjectile>();
                projectile.GetComponentInChildren<DealDamage>().SetDamage(CalcCritDamage(), crit, CritDamageMod);

                foreach (ApplyDebuff item in projectile.GetComponentsInChildren<ApplyDebuff>())
                {
                    item.SetDebuffStrenghtDuration(slowStrength, slowDuration, 1);
                }

                lastShot = Time.time;

                attacktime++;


            }
            // Attacks how ever much was put as attacktime then put on cooldown.
            if(attacktime == attacktimelimit)
            {
                attacktime = 0;
                timer = cooldown;
            }
        }
        




    }
          

}
