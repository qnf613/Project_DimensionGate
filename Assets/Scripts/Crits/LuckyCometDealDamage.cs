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
        Wep = GameObject.Find("Lucky Comet");
        LC = Wep.GetComponent<LuckyComet>();

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
    void CalcOnHit()
    {
        SetDamage(LC.CalcCritDamage(), LC.crit, LC.CritDamageMod);
    }
        //private void OnTriggerEnter2D(Collider2D collision)
        //{
        //    if (collision.gameObject.GetComponent<DamageSystem>() == null) { }
        //    else
        //    {

        //        CheckIfCrit();
        //        SetDamage(CalcCritDamage(), crit, CritDamageMod);
        //        collision.gameObject.GetComponent<DamageSystem>().TakeDamage(_dmg, CRIT);
        //        AudioSource.PlayClipAtPoint(weaponSound, transform.position, volume);
        //    }
        //}
    }
