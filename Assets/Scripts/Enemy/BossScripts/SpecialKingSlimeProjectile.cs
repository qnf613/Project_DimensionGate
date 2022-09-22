using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialKingSlimeProjectile : MonoBehaviour
{
    public int atkspeed = 1;
    public float lasthit;
    public int attackDamage;
    public float destroyTime;

    public bool slow;
    public bool burn;
    public float Strength;
    public float Duration;



    private void Start()
    {
        Destroy(this.gameObject, destroyTime);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time > atkspeed + lasthit)
        {

            if (other.gameObject.tag == "Player")
            {

                other.gameObject.GetComponent<PlayerStats>().UpdateHealth(-attackDamage);
                lasthit = Time.time;
            }
        }
    }


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
        private void OnTriggerEnter2D(Collider2D collision)
    {
        if (slow == true)
        {
            if (collision.gameObject.GetComponent<PlayerStats>() == null) { }
            else if (collision.gameObject.GetComponent<PlayerStats>() != null)
            {
                collision.gameObject.GetComponent<PlayerStats>().ApplyStatusEffect(1, Strength, Duration);

            }
        }
        if (burn == true)
        {
            if (collision.gameObject.GetComponent<PlayerStats>() == null) { }
            else if (collision.gameObject.GetComponent<PlayerStats>() != null)
            {
                collision.gameObject.GetComponent<PlayerStats>().ApplyStatusEffect(2, Strength, Duration);

            }
        }

    }












}
