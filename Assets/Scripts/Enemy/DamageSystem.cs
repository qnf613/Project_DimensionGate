using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;
//using Assets.Scripts;


public class DamageSystem : MonoBehaviour
{
    public float MaxHealth;
    public float currentHealth; /*{ get; set; }*/


    [SerializeField] private float attackDamage = 10;
    [SerializeField] private float atkspeed = 0.5f;
    [SerializeField] private float lasthit;
    [SerializeField] private TextMeshPro DamageIndicator;
    [SerializeField] private GameObject pfDamagePopup;
    [SerializeField] private Transform OffSet;
    // Start is called before the first frame update
    private void Awake()
    {
        DamageIndicator = transform.GetComponent<TextMeshPro>();
    }

    void Start()
    {
        currentHealth = MaxHealth;
        DamageIndicator = pfDamagePopup.GetComponent<TextMeshPro>();
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (Time.time > atkspeed + lasthit)
        {
            lasthit = Time.time;
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                Debug.Log("hit");

            }
        }
    }



    public virtual void TakeDamage(float damage)
    {
        ShowDamageUI(damage);
        DamagePopUp(damage);
        currentHealth -= damage;
        
        if (currentHealth < 0)
        {
            Destroy(this.gameObject);
        }
       
    }

    private void DamagePopUp(float dmg)
    {
        Instantiate(pfDamagePopup, OffSet);
        DamageIndicator.SetText(dmg.ToString());
    }

    
    private void ShowDamageUI(float dmg)
    {
        DamageIndicator.text = dmg.ToString();
        Invoke("ClearDamageUI", .5f);
    }
    private void ClearDamageUI()
    {
        DamageIndicator.text = "";
    }
}
