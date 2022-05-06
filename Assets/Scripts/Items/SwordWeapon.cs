using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordWeapon : Weapon
{
    [SerializeField] private string name = "Giant F-ing Sword";
    [SerializeField] private string description = "What else do you need to know, read the name...";
    [SerializeField] private float attackspeed = 2f;
    [SerializeField] private GameObject SwordHitBox;
    protected Vector3 projectileDirection;
    // Start is called before the first frame update
    void Start()
    {
        this.wName = name;
        this.wDescription = description;
        this.wAtkspeed = attackspeed;
        we = WeaponEquipped.yes;
        cam = Camera.main;
    }

    
    protected override void Aim()
    {
        targetPosition = cam.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotz = Mathf.Atan2(targetPosition.y, targetPosition.x) * Mathf.Rad2Deg -90f;
        transform.rotation = Quaternion.Euler(0f,0f, rotz);
        //if any changes to how weapon aims, change here
        //base.Aim();
    }
    protected override void Shoot()
    {
        
        //This weapon shoots a projectile forward
        if (Time.time > wAtkspeed + lastShot)
        {
            CheckIfCrit();
            projectileDirection = (this.transform.position - targetPosition);

            //TODO : Change this to match player Rotation and position
            AudioSource.PlayClipAtPoint(weaponSound, transform.position, volume);
            Instantiate(SwordHitBox, transform.position + targetPosition.normalized, transform.rotation, this.transform.parent);
            SwordHitBox.GetComponent<StraightProjectile>();
            SwordHitBox.GetComponent<DealDamage>().SetDamage(CalcCritDamage(), crit, CritDamageMod);

            lastShot = Time.time;
        }
    }
}
