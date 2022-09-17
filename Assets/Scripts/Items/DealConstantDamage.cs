using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealConstantDamage : MonoBehaviour
{
    public bool CRIT;
    public float damage;
    public float hittimer = 1f;
    public float hitcd = 0;
    List<DamageSystem> enemies;

    private void Start()
    {
        enemies = new List<DamageSystem>();
    }

    public virtual void SetDamage(float dmg, bool crit, float critDamage)
    {
        CRIT = crit;
        damage = dmg;
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
    private void Update()
    {
        for (var i = enemies.Count - 1; i > -1; i--)
        {
            if (enemies[i] == null)
                enemies.RemoveAt(i);
        }

        if (Time.time > hitcd)
        {
            // Do damage here         
            foreach (var item in enemies)
            {
                item.TakeDamage(damage, CRIT);
            }
            
            hitcd = Time.time + hittimer;
        }
    }

}
