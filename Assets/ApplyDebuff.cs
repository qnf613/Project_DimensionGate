using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDebuff : MonoBehaviour
{
    public bool slow;
    public float slowStrenght;
    public float slowDuration;
   
    public void SetDebuffStrenghtSlow(float _slowStrenght, float _duration)
    {
        slowStrenght = _slowStrenght;
        slowDuration = _duration;
    }

    /*
     * Summary : pass in a number which determins the type of status effect applied to target.
     * 1 = slow
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (slow == true)
        {
            if (collision.gameObject.GetComponent<DamageSystem>() == null) { }
            else if (collision.gameObject.GetComponent<DamageSystem>() != null)
            {
                collision.gameObject.GetComponent<DamageSystem>().ApplyStatusEffect(1, slowStrenght, slowDuration);

            }
        }
    }
}
