using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

//using Assets.Scripts;


public class DamageSystem : MonoBehaviour
{
    
    [SerializeField] public float MaxHealth;
    [SerializeField] public float currentHealth; /*{ get; set; }*/
    [SerializeField] public float newMaxHealth;

    [SerializeField] private float attackDamage = 10;
    [SerializeField] private float atkspeed = 0.5f;
    [SerializeField] private float lasthit;

    [SerializeField] private TextMeshPro DamageIndicator;
    [SerializeField] private GameObject pfDamagePopup;

    [SerializeField] private GameObject OffSet;
    [SerializeField] private Transform TempPosition;
    [SerializeField] private SpriteFlash flashEffect;
    [SerializeField] private float originalFontSize = 36;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private AudioClip enemydamageSFX;
    [SerializeField] private float enemyvolume = 0.50f;

    BossUIManager BossManager;
    public bool isBoss;



    
    private void Awake()
    {
        DamageIndicator = transform.GetComponent<TextMeshPro>();
        BossManager = GetComponent<BossUIManager>();
    }

    void Start()
    {
        //if (!isBoss)
        //{

        //}
        
        currentHealth = newMaxHealth;
        DamageIndicator = pfDamagePopup.GetComponent<TextMeshPro>();
        DamageIndicator.fontSize = originalFontSize;
        


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



    public virtual void TakeDamage(float damage, bool crit)
    {

        flashEffect.Flash();
        DamagePopUp(damage, crit);
        if (!isBoss)
        {
            currentHealth -= damage;
        }
        else if (isBoss && BossManager != null)
        {
            currentHealth -= damage;
            BossManager.UpdateBossHealth(currentHealth);
        }

        if (!isBoss && currentHealth <= 0)
        {

            ParticleSystem explosion = (ParticleSystem)Instantiate(explosionParticle);
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);
            Destroy(explosion.gameObject, 2f);
            Destroy(this.gameObject, 0.15f);
        }
        else if (isBoss && currentHealth <= 0 && BossManager != null)
        {
            ParticleSystem explosion = (ParticleSystem)Instantiate(explosionParticle);
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);
            BossManager.HealthBarInactive();
            Destroy(explosion.gameObject, 2f);
            Destroy(this.gameObject, 0.15f);
        }

        if (enemydamageSFX != null)
        {
            AudioSource.PlayClipAtPoint(enemydamageSFX, transform.position, enemyvolume);
        }

    }
    public void DamagePopUp(float dmg, bool crit)
    {
        float randomAngle;
        float randomOffset;
        randomOffset = UnityEngine.Random.Range(-1f, 1.5f);
        Vector3 TempOffset = new Vector3(OffSet.transform.position.x + randomOffset, OffSet.transform.position.y, 0);
        SetFont(dmg);
        ShowDamageUI(dmg, crit);
        Instantiate(pfDamagePopup, TempOffset, Quaternion.identity);
        ResetFontSize();

    }
    void SetFont(float dmg)
    {
        DamageIndicator.fontSize += dmg * .5f;
        if (DamageIndicator.fontSize > 100)
        {
            DamageIndicator.fontSize = 100;
        }
        //Debug.Log(DamageIndicator.fontSize);
    }

    private void ShowDamageUI(float dmg, bool crit)
    {
        if (dmg == 0) { }
        else
        {
            if (crit == true)
            {
                DamageIndicator.color = Color.red;
            }
            else if (crit == false)
            {
                DamageIndicator.color = Color.white;
            }

            DamageIndicator.text = ((int)dmg).ToString();
            Invoke("ClearDamageUI", .5f);
        }

    }
    void ResetFontSize()
    {
        DamageIndicator.fontSize = originalFontSize;
    }
    private void ClearDamageUI()
    {
        DamageIndicator.text = "";
    }

    
}

   
