using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPickup : MonoBehaviour
{
    [SerializeField] private float healAmount;
    [SerializeField] private float lifespan;

    private void Start()
    {
        Destroy(this.gameObject, lifespan);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().UpdateHealth(healAmount);
            Destroy(this.gameObject);
        }
    }
}
