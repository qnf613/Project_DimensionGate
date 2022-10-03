using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDebuff : MonoBehaviour
{
    public bool slow, burn, bleed;
    public float Strength;
    public float Duration;
    

    public void SetDebuffStrenghtDuration(float _Strength, float _duration, float _debuffType)
    {
        Strength = _Strength;
        Duration = _duration;
        switch (_debuffType)
        {
            case 1:
                slow = true;
                break;
            case 2:
                burn = true;
                break;
            case 3:
                bleed = true;
                break;
        }

    }
    /*
     * Summary : pass in a number which determins the type of status effect applied to target.
     * 1 = slow
     * 2 = burn
     */
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (slow == true)
        {
            if (collision.gameObject.GetComponent<DamageSystem>() == null) { }
            else if (collision.gameObject.GetComponent<DamageSystem>() != null)
            {
                collision.gameObject.GetComponent<DamageSystem>().ApplyStatusEffect(1, Strength, Duration, this.gameObject.name);

            }
        }
        if (burn == true)
        {
            if (collision.gameObject.GetComponent<DamageSystem>() == null) { }
            else if (collision.gameObject.GetComponent<DamageSystem>() != null)
            {
                collision.gameObject.GetComponent<DamageSystem>().ApplyStatusEffect(2, Strength, Duration, this.gameObject.name);

            }
        }
        if (bleed == true)
        {
            if (collision.gameObject.GetComponent<DamageSystem>() == null) { }
            else if (collision.gameObject.GetComponent<DamageSystem>() != null)
            {
                collision.gameObject.GetComponent<DamageSystem>().ApplyStatusEffect(3, Strength, Duration, this.gameObject.name);

            }
        }
    }
}

