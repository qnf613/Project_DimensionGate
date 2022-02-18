using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Assets.Scripts;


public class DamageSystem : MonoBehaviour
{
    public float MaxHealth;
    public float currentHealth; /*{ get; set; }*/

    [SerializeField] private float attackDamage = 10;
    [SerializeField] private float atkspeed = 0.5f;
    [SerializeField] private float lasthit;

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
        else if (currentHealth <= 0 && this.tag == "Spawner")
        {

            this.gameObject.layer = 8;
            this.GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    private void Update()
    {

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time > atkspeed + lasthit)
        {
            lasthit = Time.time;
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                Debug.Log("hit");
            }
        }
        

    }
}
