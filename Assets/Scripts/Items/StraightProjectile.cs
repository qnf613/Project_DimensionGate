using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StraightProjectile : MonoBehaviour
{
    //this is script for projectile that shoot straightly
    Rigidbody2D rb;
    public float speed = 20;
    public float lifespan = 3;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        //this.transform.Translate(transform.right * projectileSpeed * Time.deltaTime);
        Destroy(this.gameObject, lifespan);
    }
    private void Update()
    {
        if (!gameObject.GetComponentInChildren<SpriteRenderer>().isVisible)
        {
            Debug.Log("I got off from scene");
            Destroy(this.gameObject);
        }
    }
}
