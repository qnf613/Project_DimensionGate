using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConstantDamageScript : MonoBehaviour
{
    [SerializeField] private float attackDelay = .5f;
    [SerializeField] private float nextDamageEvent;
    [SerializeField] private float duration;

    private float attackDamage;
    private float FinalDamage;
    private GameObject VenomFlask;
    
    private float volume = 0.6f;

    List<DamageSystem> enemies;

    private void Start()
    {
        enemies = new List<DamageSystem>();
        VenomFlask = GameObject.Find("Venom Flask");
        var venomscript = VenomFlask.GetComponent<PoisonFlask>();
        attackDamage = venomscript.dotDamage;
        SetDamage();

        Invoke("SetDamage", duration);
    }

    public void SetDamage()
    {
        FinalDamage = attackDamage;
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

        if (Time.time >= nextDamageEvent)
        {

            // Do damage here         
            foreach (var item in enemies)
            {
                item.TakeDamage(FinalDamage, false);
            }
            DamageScale();
            nextDamageEvent = Time.time + attackDelay;
        }
        
        //The pool should only last a few seconds
        Destroy(this.gameObject, duration);

    }
void DamageScale()
    {
        FinalDamage *= VenomFlask.GetComponent<PoisonFlask>().dotDamageScale;
        
    }
}
