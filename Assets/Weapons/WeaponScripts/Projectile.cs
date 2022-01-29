using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 10;
    public float lifespan = 3;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        //this.transform.Translate(transform.right * projectileSpeed * Time.deltaTime);
        Destroy(this.gameObject, lifespan);
    }
}
