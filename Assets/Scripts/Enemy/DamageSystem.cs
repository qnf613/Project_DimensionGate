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
    [SerializeField] private GameObject OffSet;
    [SerializeField] private Transform TempPosition;
    [SerializeField] private SpriteFlash flashEffect;

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
            
            if (other.gameObject.tag == "Player")
            {
                other.gameObject.GetComponent<PlayerHealth>().UpdateHealth(-attackDamage);
                lasthit = Time.time;
            }
        }
    }



    public virtual void TakeDamage(float damage)
    {
        ShowDamageUI(damage);
        DamagePopUp(damage);
        flashEffect.Flash();
        currentHealth -= damage;
        
        if (currentHealth <= 0)
        {
            Destroy(this.gameObject, 0.25f);
        }
       
    }

    private void DamagePopUp(float dmg)
    {
        float randomAngle;
        float randomOffset;
        randomOffset = UnityEngine.Random.Range(-1f,1.5f);
        Vector3 TempOffset = new Vector3(OffSet.transform.position.x + randomOffset, OffSet.transform.position.y,0);
        Instantiate(pfDamagePopup, TempOffset, Quaternion.identity);
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
