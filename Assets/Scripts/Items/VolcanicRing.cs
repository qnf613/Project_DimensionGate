using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanicRing : Weapon
{
    public float burnDamage;
    public float burnDuration;


    private void Update()
    {
        base.Update();
        burnDamage = damage / 5;
    }
    protected override void Aim()
    {
        targetPosition = cam.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0;
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
                Instantiate(projectile, targetPosition, transform.rotation);
                projectile.GetComponent<ApplyDebuff>().SetDebuffStrenghtDuration(burnDamage, burnDuration, 2);
                projectile.GetComponent<StraightProjectile>();
                projectile.GetComponent<DealDamage>().SetDamage(CalcCritDamage(), crit, CritDamageMod);
            }         
            lastShot = Time.time;
        }
    }
}
