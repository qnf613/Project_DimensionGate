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
    private GameObject PoisonFlask;
    
    private float volume = 0.6f;

    List<DamageSystem> enemies;

    void Start()
    {  
        enemies = new List<DamageSystem>();
        PoisonFlask = GameObject.Find("Poison Flask");
        var venomscript = PoisonFlask.GetComponent<PoisonFlask>();
        attackDamage = venomscript.damage;
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
        if (PoisonFlask == null)
        {
            Destroy(this.gameObject);
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
        FinalDamage *= PoisonFlask.GetComponent<PoisonFlask>().dotDamageScale;
        
    }
}
