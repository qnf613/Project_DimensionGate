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
                item.SetDebuffStrenghtSlow(slowStrength, slowDuration);
            }
           
            lastShot = Time.time;
        }
    }
}

