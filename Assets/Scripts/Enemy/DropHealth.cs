using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropHealth : MonoBehaviour
{
    
    [SerializeField] private GameObject healthDrop;
    [SerializeField] private float dropOdds;

    
    public void dropHealth()
    {
        float random = Random.Range(1, 100);
       // Debug.Log("Rolled a " + random);
        if (dropOdds >= random)
        {
            Vector2 currentlocation = this.GetComponent<Rigidbody2D>().transform.position;
            Quaternion currentrotation = this.GetComponent<Rigidbody2D>().transform.rotation;
            Instantiate(healthDrop, currentlocation, currentrotation);
        }
    }
}
