using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonFlaskStraightProjectile : MonoBehaviour
{
    Rigidbody2D rb;
    public float speed = 20;
    public float lifespan = 3;
    public GameObject PosionPool;
    Vector3 pos;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        //this.transform.Translate(transform.right * projectileSpeed * Time.deltaTime);
        
        Invoke("LifeSpan", lifespan);
    }
    void LifeSpan()
    {
        Vector2 currentlocation = PosionPool.GetComponent<Rigidbody2D>().transform.position;
        Quaternion currentrotation = PosionPool.GetComponent<Rigidbody2D>().transform.rotation;
        Instantiate(PosionPool, currentlocation, currentrotation);
        Destroy(this.gameObject);
    }
}
