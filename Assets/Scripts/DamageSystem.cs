using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Assets.Scripts;


public class DamageSystem : MonoBehaviour
{
    public float MaxHealth;
    public float currentHealth { get; set; }
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;
    }

    // Update is called once per frame
    public virtual void TakeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0 && this.tag != "Spawner")
        {
            Destroy(this.gameObject);
        }
        else if (currentHealth <= 0 &&this.tag == "Spawner")
        {
            
            this.gameObject.layer = 8;
            this.GetComponent<SpriteRenderer>().enabled = false;
            //this.GetComponent<TimedSpawner>().deadspawner = true;
        }
    }

}

