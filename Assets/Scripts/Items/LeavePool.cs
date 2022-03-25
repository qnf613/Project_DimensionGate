using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeavePool : MonoBehaviour
{

    [SerializeField] private GameObject poisonFieldPrefab;
    [SerializeField] private GameObject poisonFlaskProjectile;
    [SerializeField] protected AudioClip sfx;
    [SerializeField] protected float volume = 0.50f;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageSystem>() == null) { }
        else
        {
            
            // grabs the location at which the projectile hit an enemy
            Vector2 currentlocation = poisonFlaskProjectile.GetComponent<Rigidbody2D>().transform.position;
            Quaternion currentrotation = poisonFlaskProjectile.GetComponent<Rigidbody2D>().transform.rotation;

            //spawns poison field at the location the projectile vanished 
            AudioSource.PlayClipAtPoint(sfx, transform.position, volume);
            Instantiate(poisonFieldPrefab, currentlocation, currentrotation);
            //destroys projectile
            Destroy(this.gameObject);
        }
    }



}
