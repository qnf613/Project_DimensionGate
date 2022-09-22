using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : PickUp
{
    [SerializeField] private float healAmount;
    [SerializeField] private float lifespan;

    private void Start()
    {
        Destroy(this.gameObject, lifespan);
    }
    protected override void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerStats>().UpdateHealth(healAmount);
            PickedUp();
        }
    }

    protected override void PickedUp()
    {
        Destroy(this.gameObject);
    }
}
