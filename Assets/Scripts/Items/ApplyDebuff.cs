using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplyDebuff : MonoBehaviour
{
    public bool slow;
    public bool burn;
    public float Strength;
    public float Duration;
    bool spread;

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
        }

    }
    public void SetDebuffStrenghtDuration(float _Strength, float _duration, float _debuffType, bool _spread)
    {
        Strength = _Strength;
        Duration = _duration;
        spread = _spread;
        switch (_debuffType)
        {
            case 1:
                slow = true;
                break;
            case 2:
                burn = true;
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
                collision.gameObject.GetComponent<DamageSystem>().ApplyStatusEffect(1, Strength, Duration);

            }
        }
        if (burn == true)
        {
            if (collision.gameObject.GetComponent<DamageSystem>() == null) { }
            else if (collision.gameObject.GetComponent<DamageSystem>() != null)
            {
                collision.gameObject.GetComponent<DamageSystem>().ApplyStatusEffect(2, Strength, Duration);

            }
        }
        if (burn == true && spread == true)
        {
            if (collision.gameObject.GetComponent<DamageSystem>() == null) { }
            else if (collision.gameObject.GetComponent<DamageSystem>() != null)
            {
                collision.gameObject.GetComponent<DamageSystem>().ApplyStatusEffect(2, Strength, Duration, true);

            }
        }
    }
}
