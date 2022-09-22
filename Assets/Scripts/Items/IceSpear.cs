using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceSpear : Weapon
{
    public float slowStrength;
    public float slowDuration;
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
                item.SetDebuffStrenghtDuration(slowStrength, slowDuration, 1);
            }
           
            lastShot = Time.time;
        }
    }
    public override void specialRefines()
    {
        if (enhancement == 3)
        { //50% damage boost
            this.damage *= 1.5f;
        }
        if (enhancement == 6)
        { //+20% slow strength
            slowStrength *= 1.2f;
        }
        if (enhancement == 9)
        {
            //20% slow strength / +20% slow duration
            slowStrength *= 1.2f;
            slowDuration *= 1.2f;
        }
    }
}

