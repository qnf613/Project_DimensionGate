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

    [SerializeField] private GameObject pfDamagePopup;

    [SerializeField] private GameObject OffSet;
    [SerializeField] private Transform TempPosition;
    [SerializeField] private SpriteFlash flashEffect;
    [SerializeField] private float originalFontSize = 36;
    [SerializeField] private ParticleSystem explosionParticle;
    [SerializeField] private AudioClip enemydamageSFX;
    [SerializeField] private float enemyvolume = 0.50f;
    public DPSMeter dpsm;

    [SerializeField]private DropHealth healthPickup;

    bool slowed = false;
    public bool burning = false, bleeding = false;
    float tickSpeed = 1, lastTickBurn, lastTickBleed;
    public float burnstr, bleedstr;
    public float burnDuration,slowDuration;
    float originalspeed;
    BossUIManager BossManager;
    public bool isBoss;

    public float statustype, statusStrength, statusDuration;

    [SerializeField] private PlayerStats playerSTATS_Script;
    [SerializeField] private GameObject playerGameObject;
    public List<string> origins = new List<string>(); // this will keep track of what has applyed debuffs

    private void Awake()
    {
        currentHealth = newMaxHealth;
        BossManager = GetComponent<BossUIManager>();
        if (this.gameObject.GetComponent<Pathfinding.AIPath>() != null)
        {
            originalspeed = this.gameObject.GetComponent<Pathfinding.AIPath>().maxSpeed;
        }
    }

    void Start()
    {
        playerGameObject = GameObject.FindWithTag("Player");
        playerSTATS_Script = playerGameObject.GetComponent<PlayerStats>();
        if (GameObject.Find("DPS Meter").GetComponent<DPSMeter>() != null)
        {
            dpsm = GameObject.Find("DPS Meter").GetComponent<DPSMeter>();
        }
        currentHealth = newMaxHealth;
        healthPickup = GetComponent<DropHealth>();
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
    public virtual void ApplyStatusEffect(float status, float Strength, float duration, List<string> origin)
    {
        statustype = status;
        statusStrength = Strength;
        statusDuration = duration;
        foreach (var item in origins)
        {
            if (!origins.Contains(item))
            {
            origins.Add(item);
            }
        }
        if (status == 1)
        {
            if (this.gameObject.GetComponent<Pathfinding.AIPath>() != null || this.gameObject.GetComponentInChildren<Pathfinding.AIPath>() != null)
            {
                slowed = true;
                Strength = 1 - Strength / 100;
                if (Strength > 80)
                {
                    Strength = 80;
                }
                this.gameObject.GetComponent<Pathfinding.AIPath>().maxSpeed *= Strength;
            }
        }
        if (status == 2)
        {
            foreach (var item in origin)
            {
                if (!origins.Contains(item))
                {
                    burnDuration += duration;
                    origins.Add(item);
                    burnstr += Strength;
                }
                burning = true;
            }
        }
        if (status == 3)
        {
            bleedstr = Strength * playerSTATS_Script.BaseDMG; // // TODO: Jin, whenever you add a mod to sideeffects, pls substitute the baseDMG to whatever the mod is.
            bleeding = true;
        }
    }
    public virtual void ApplyStatusEffect(float status, float Strength, float duration, string origin)
    {
        statustype = status;
        statusStrength = Strength;
        statusDuration = duration;
        
       
        if (status == 1)
        {
            if (this.gameObject.GetComponent<Pathfinding.AIPath>() != null || this.gameObject.GetComponentInChildren<Pathfinding.AIPath>() != null)
            {
                slowed = true;
                Strength = 1 - Strength / 100;
                if (Strength > 80)
                {
                    Strength = 80;
                }
                this.gameObject.GetComponent<Pathfinding.AIPath>().maxSpeed *= Strength;
            }
        }
        if (status == 2)
        {
           
            if (!origins.Contains(origin))
            {
                burnDuration += duration;
                burning = true;
                origins.Add(origin);
                burnstr += Strength;
            }
            if (origins.Contains(origin))
            {
                burnDuration += duration / 3;
            }
        }
        if (status == 3)
        {
            bleedstr = Strength * playerSTATS_Script.BaseDMG; // // TODO: Jin, whenever you add a mod to sideeffects, pls substitute the baseDMG to whatever the mod is.
            bleeding = true;
        }
    }
    private void Update()
    {
        if (burning == true)
        {
            BurnDealTickDamage(burnstr);
            burnDuration -= Time.deltaTime;
            if (burnDuration <0)
            {
                RemoveStatusEffectBurn();
            }
            Debug.Log("Dealing :" + burnstr);
        }
        if (slowed == true)
        {
            slowDuration -= Time.deltaTime;
            if ( slowDuration< 0)
            {
                RemoveStatusEffectSlow();
            }
        }
        if (bleeding == true)
        {
            var dmg = ((bleedstr / 100) * MaxHealth);
            if (dmg <1)
            {
                dmg = 1;
            }
            BleedDealTickDamage(dmg);
            Debug.Log("Dealing :"+ (bleedstr / 100) * MaxHealth);
        }
    }
    private void BurnDealTickDamage(float str)
    {
        if (Time.time > tickSpeed / 3 + lastTickBurn)
        {
            TakeDamage(str, false);
            lastTickBurn = Time.time;
        }
    }
    private void BleedDealTickDamage(float str)
    {
        if (Time.time > tickSpeed /3+ lastTickBleed)
        {
            TakeDamage(str, false);
            lastTickBleed = Time.time;
        }
    }
    private void RemoveStatusEffectBurn() { burning = false; origins.Clear(); burnstr = 0; }
    private void RemoveStatusEffectSlow()
    {
       
        this.gameObject.GetComponent<Pathfinding.AIPath>().maxSpeed = originalspeed;
       // this.gameObject.GetComponent<Pathfinding.AIPath>().speed = originalspeed;
        
        slowed = false;
    }

    public void DPOPup(float dmg, bool crit)
    {
        float randomAngle;
        float randomOffsetx;
        float randomOffsety;
        randomOffsetx = UnityEngine.Random.Range(-.5f, .5f);
        randomOffsety = UnityEngine.Random.Range(-.5f, 0.5f);

        Vector3 TempOffset = new Vector3(OffSet.transform.position.x + randomOffsetx, OffSet.transform.position.y + randomOffsety, 0);
        GameObject go = Instantiate(pfDamagePopup, TempOffset, Quaternion.identity);
        go.GetComponent<DamagePopUp>().SetValues(dmg,crit,OffSet);
        Destroy(go, .5f);
    }
    public virtual void TakeDamage(float damage, bool crit)
    {
        DpsMeterData(damage, crit);
        flashEffect.Flash();
        DPOPup(damage, crit);
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
            healthPickup.dropHealth();
            Destroy(explosion.gameObject, 2f);
            Destroy(this.gameObject, 0.15f);
        }
        else if (isBoss && currentHealth <= 0 && BossManager != null)
        {
            ParticleSystem explosion = (ParticleSystem)Instantiate(explosionParticle);
            explosion.transform.position = new Vector3(transform.position.x, transform.position.y + .3f, transform.position.z);
            healthPickup.dropHealth();
            BossManager.HealthBarInactive();
            Destroy(explosion.gameObject, 2f);
            Destroy(this.gameObject, 0.15f);
        }

        if (enemydamageSFX != null)
        {
            AudioSource.PlayClipAtPoint(enemydamageSFX, transform.position, enemyvolume);
        }

    }
    public void DpsMeterData(float d, bool c)
    {
        if (dpsm != null)
        {
            dpsm.ArrangeCalcs(d, c);
        }  
    }
   
}

   
