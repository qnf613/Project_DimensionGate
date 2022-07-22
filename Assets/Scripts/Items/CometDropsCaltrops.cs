using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CometDropsCaltrops : LuckierComet
{
    private float timer = 1f;
    [SerializeField] public float attacktime = 2f;
    [SerializeField] public float attacktimelimit = 5;
    [SerializeField] public float cooldown = 10f;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        Shoot();
    }
   
    protected override void Shoot()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
        if (timer <= 0)
        {
            if (Time.time > wAtkspeed + lastShot)
            {
                
                AudioSource.PlayClipAtPoint(weaponSound, transform.position, volume);
                
                
               // Instantiate(projectile, randomPos, transform.rotation);
                

                projectile.GetComponent<DealDamage>().SetDamage(CalcCritDamage(), crit, CritDamageMod);

                lastShot = Time.time;

                attacktime++;
            }
            // Attacks how ever much was put as attacktime then put on cooldown.
            if (attacktime == attacktimelimit)
            {
                attacktime = 0;
                timer = cooldown;
            }
        }
        

    }

    public float CalcCritDamage()
    {
        CheckIfCrit();
        if (crit == true)
        {
            finalDamageNumber = this.gameObject.GetComponentInParent<Refine>().ChangeDamageBasedOnRefine(damage) * CritDamageMod;
        }
        else if (crit == false)
        {
            finalDamageNumber = this.gameObject.GetComponentInParent<Refine>().ChangeDamageBasedOnRefine(damage);
        }
        return finalDamageNumber;
    }
}
