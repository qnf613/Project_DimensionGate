using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBolt : Weapon
{

    [SerializeField] private string name = "Fire Bolt";
    [SerializeField] private string description = "Shoot a fire bolt";
    [SerializeField] private int range = 20;
    [SerializeField] private float attackspeed = .7f;
    public float burnDamage;
    public float burnDuration;
    private float bd;


    protected Vector3 projectileDirection;

    private void Start()
    {
        bd = damage / 5;
    }

    protected override void Update()
    {
        base.Update();
        burnDamage = bd;
    }
    protected override void Aim()
    {
        targetPosition = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
    }
    protected override void Shoot()
    {

        //This weapon shoots a projectile forward
        if (Time.time > attackspeed + lastShot)
        {
           
            CheckIfCrit();
            AudioSource.PlayClipAtPoint(weaponSound, transform.position, volume);
            if (projectile != null)
            {
                Instantiate(projectile, transform.position, transform.rotation);
            }
            projectile.GetComponent<ApplyDebuff>().SetDebuffStrenghtDuration(burnDamage, burnDuration, 2);
            projectile.GetComponent<StraightProjectile>();
            projectile.GetComponent<DealDamage>().SetDamage(CalcCritDamage(), crit, CritDamageMod);


            projectileDirection = (this.transform.position - targetPosition);
            lastShot = Time.time;
        }
   
    }
    public override void specialRefines()
    {
        if (enhancement == 3)
        {//+20% atkspeed
            this.attackspeed *= .8f;
            this.wAtkspeed *= .8f;
        }
        if (enhancement == 6)
        {//50% longer burn duration
            this.burnDuration *= 1.5f;
        }
        if (enhancement >= 9)
        {//double burn damage
            bd = damage / 2.5f;
        }
        if (enhancement <9)
        {
            bd = damage / 5;
        }
    }
}
