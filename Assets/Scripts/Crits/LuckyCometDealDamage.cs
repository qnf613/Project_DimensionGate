using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyCometDealDamage : MonoBehaviour
{
    public bool CRIT;
    private float _dmg;
    public GameObject Wep;
    public LuckyComet LC;
    [SerializeField] private float attackDelay = .5f;
    [SerializeField] private float nextDamageEvent;

    List<DamageSystem> enemies;

    private float timer = 1f;
    [SerializeField] public float attacktime = 2f;
    [SerializeField] public float attacktimelimit = 5;
    [SerializeField] public float cooldown = 10f;
    private float lastShot;
    public bool luckiercometCheck;

    public GameObject projectile;
    private void Start()
    {
        enemies = new List<DamageSystem>();
    }
    public void SetDamage(float dmg, bool crit, float critDamage)
    {
        CRIT = crit;
        if (crit == true)
        {
            _dmg = dmg;
        }
        else
        {
            _dmg = dmg;
        }

    }
    private void Update()
    {
        if (luckiercometCheck == true)
        {
            dropCaltrops();
        }

        for (var i = enemies.Count - 1; i > -1; i--)
        {
            if (enemies[i] == null)
                enemies.RemoveAt(i);
        }
        if (Time.time >= nextDamageEvent)
        {

            // Do damage here         
            foreach (var item in enemies)
            {
                CalcOnHit();
                item.TakeDamage(_dmg, CRIT);
            }
            
            nextDamageEvent = Time.time + attackDelay/2;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.GetComponent<DamageSystem>() != null)
            {
                enemies.Add(collision.GetComponent<DamageSystem>());
            }
        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision != null)
        {
            if (collision.GetComponent<DamageSystem>() != null)
            {
                enemies.Remove(collision.GetComponent<DamageSystem>());
            }
        }
    }
    void dropCaltrops() 
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;

        }
        if (timer <= 0)
        {
            if (Time.time > LC.wAtkspeed + lastShot)
            {
                float xOffSet = Random.Range(-1.5f, 1.5f);
                float yOffSet = Random.Range(-1.5f, 1.5f);
                Vector3 randomPos = new Vector3(transform.position.x + xOffSet, transform.position.y + yOffSet);

                LC.CheckIfCrit();
                AudioSource.PlayClipAtPoint(LC.weaponSound, transform.position, LC.volume);
                Instantiate(projectile, randomPos, transform.rotation);
                
                projectile.GetComponent<DealDamage>().SetDamage(LC.CalcCritDamage(), LC.crit, LC.CritDamageMod);

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
    void CalcOnHit()
    {
        SetDamage(LC.CalcCritDamage(), LC.crit, LC.CritDamageMod);
    }    
}
