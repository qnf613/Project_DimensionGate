using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcaneExplosive : Weapon
{
    protected Vector3 projectileDirection;
    // Start is called before the first frame update

    protected override void Aim()
    {
        targetPosition = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg - 90f;
        transform.rotation = Quaternion.Euler(0f, 0f, rotz);
    }

    // Update is called once per frame
    protected override void Shoot()
    { 
        
        if (Time.time > wAtkspeed + lastShot)
        {
            CheckIfCrit();
            projectileDirection = (this.transform.position - targetPosition);
            //TODO : Change this to match player Rotation and position
            AudioSource.PlayClipAtPoint(weaponSound, transform.position, volume);

            
            Instantiate(projectile, transform.position + targetPosition.normalized, transform.rotation);
            projectile.GetComponent<Explode>().GetExplosionDamage(CalcCritDamage(), crit, CritDamageMod);

            lastShot = Time.time;
        }
    }
}
