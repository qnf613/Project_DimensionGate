using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiplyProjectile : MonoBehaviour
{
    //public Transform spawnLocation;
    public GameObject thisObject;
    public GameObject spawnNewObject;
    public Transform enemyCollision;
    

    Rigidbody2D rb;
    public float speed = 20;
    public float lifespan = 3;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.AddForce(transform.up * speed, ForceMode2D.Impulse);
        Destroy(this.gameObject, lifespan);
        
    }
    private void Update()
    {
        //spawnLocation = thisObject.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageSystem>() == null) { }
        else if (collision.gameObject.GetComponent<DamageSystem>() != null)
        {
            enemyCollision = gameObject.GetComponent<Transform>();
            thisObject = Instantiate(spawnNewObject, enemyCollision.transform.position, transform.rotation);
            

        }
        
    }
}
