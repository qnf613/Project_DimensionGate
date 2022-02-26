using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionIgnore : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    void Start()
    {
      Player = GameObject.FindGameObjectWithTag("Player");
       Physics2D.IgnoreCollision(Player.GetComponent<CapsuleCollider2D>(), this.GetComponent<BoxCollider2D>());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
