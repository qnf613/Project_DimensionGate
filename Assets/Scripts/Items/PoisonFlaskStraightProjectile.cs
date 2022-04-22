using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonFlaskStraightProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 20;
    public float lifespan = 3;
    public GameObject poisonFieldPrefab;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        //this.transform.Translate(transform.right * projectileSpeed * Time.deltaTime);
        
        Destroy(this.gameObject, lifespan);
    }
    private void OnDestroy()
    {
        Instantiate(poisonFieldPrefab, this.gameObject.transform.position, this.gameObject.transform.rotation);
    }
}
