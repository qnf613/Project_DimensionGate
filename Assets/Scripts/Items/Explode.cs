using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explode : Rocket
{
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private GameObject rocketPrefab;
  
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<DamageSystem>() == null) { }
        else
        {
            // grabs the location at which the projectile hit an enemy
            Vector2 currentlocation = rocketPrefab.GetComponent<Rigidbody2D>().transform.position;
            Quaternion currentrotation = rocketPrefab.GetComponent<Rigidbody2D>().transform.rotation;
            //spawns poison field at the location the projectile vanished 
            Instantiate(explosionPrefab, currentlocation, currentrotation);
            //destroys projectile
            Destroy(this.gameObject);


        }
    }
    public void GetExplosionDamage(float damage) 
    {
        explosionPrefab.GetComponent<DealDamage>().SetDamage(damage, crit, CritDamageMod);
    }
}
