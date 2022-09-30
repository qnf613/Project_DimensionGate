using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VolcanicRing : Weapon
{
    public float burnDamage;
    public float burnDuration;
    [SerializeField] GameObject UPGProjectile;
    private void Start()
    {
        burnDamage = CalcCritDamage()/5;
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
                projectile.GetComponent<ApplyDebuff>().SetDebuffStrenghtDuration(burnDamage, burnDuration, 2, true);
                projectile.GetComponent<StraightProjectile>();
                projectile.GetComponent<DealDamage>().SetDamage(CalcCritDamage(), crit, CritDamageMod);
            }         
            lastShot = Time.time;
        }
    }
    public override void specialRefines()
    {
        if (enhancement == 3)
        {//+50% atkspeed buff
            this.wAtkspeed *= .5f;
        }
        if (enhancement == 6)
        {
            this.projectile = UPGProjectile;
            this.burnDamage *= 2;
        }
        if (enhancement == 9)
        {
            this.damage *= 2;
        }
    }
    protected override void Update()
    {
        CheckBURNLVL();
        base.Update();
    }
    void CheckBURNLVL()
    {
        if (enhancement >= 6 && enhancement <9)
        {
            burnDamage = damage / 2.5f;
        }
        if (enhancement >=9)
        {
            burnDamage = damage;
        }
    }
}
