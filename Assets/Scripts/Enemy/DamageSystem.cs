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
    public DPSMeter dpsm;

    [SerializeField]private DropHealth healthPickup;

    bool slowed = false;
    public bool burning = false, bleeding = false;
    float burntickSpeed = 1, lastTick;
    public float burnstr, bleedstr;

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
        DamageIndicator = transform.GetComponent<TextMeshPro>();
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
        DamageIndicator = pfDamagePopup.GetComponent<TextMeshPro>();
        DamageIndicator.fontSize = originalFontSize;
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
        if (Strength > 80)
        {
            Strength = 80;
        }
        if (status == 1 && slowed == false)
        {
            if (this.gameObject.GetComponent<Pathfinding.AIPath>() != null || this.gameObject.GetComponentInChildren<Pathfinding.AIPath>() != null)
            {
                slowed = true;
                Strength = 1 - Strength / 100;
                this.gameObject.GetComponent<Pathfinding.AIPath>().maxSpeed *= Strength;

                Invoke("RemoveStatusEffectSlow", duration);
            }
        }
        if (status == 2)
        {
            foreach (var item in origin)
            {
                if (!origins.Contains(item))
                {
                    origins.Add(item);
                    burnstr += Strength;
                }
                Invoke("RemoveStatusEffectBurn", duration);
                burning = true;
            }
        }
        if (status == 3 && bleeding == false)
        {
            bleedstr = Strength / 100 + playerSTATS_Script.BaseDMG; // // TODO: Jin, whenever you add a mod to sideeffects, pls substitute the baseDMG to whatever the mod is.
            bleeding = true;
        }
    }
    public virtual void ApplyStatusEffect(float status, float Strength, float duration, string origin)
    {
        statustype = status;
        statusStrength = Strength;
        statusDuration = duration;
        
        if (Strength >80)
        {
            Strength = 80;
        }
        if (status == 1 && slowed == false)
        {
            if (this.gameObject.GetComponent<Pathfinding.AIPath>() != null || this.gameObject.GetComponentInChildren<Pathfinding.AIPath>() != null)
            {
                slowed = true;
                Strength = 1 - Strength / 100;
                this.gameObject.GetComponent<Pathfinding.AIPath>().maxSpeed *= Strength;

                Invoke("RemoveStatusEffectSlow", duration);
            }
        }
        if (status == 2)
        {
            if (!origins.Contains(origin))
            {
                origins.Add(origin);
                burnstr += Strength;
            }
            Invoke("RemoveStatusEffectBurn", duration);
            burning = true;
        }
        if (status == 3 && bleeding == false)
        {
            bleedstr = Strength / 100 + playerSTATS_Script.BaseDMG; // // TODO: Jin, whenever you add a mod to sideeffects, pls substitute the baseDMG to whatever the mod is.
            bleeding = true;
        }
    }
    private void Update()
    {
        if (burning == true)
        {
            DealTickDamage(burnstr);
        }
        if (bleeding == true)
        {
            DealTickDamage(bleedstr);
        }
    }
    private void DealTickDamage(float str)
    {
        if (Time.time > burntickSpeed/3 + lastTick)
        {
            TakeDamage(str, false);
            lastTick = Time.time;
        }
    }
    private void RemoveStatusEffectBurn() { burning = false; origins.Clear(); burnstr = 0; }
    private void RemoveStatusEffectSlow()
    {
       
        this.gameObject.GetComponent<Pathfinding.AIPath>().maxSpeed = originalspeed;
       // this.gameObject.GetComponent<Pathfinding.AIPath>().speed = originalspeed;
        
        slowed = false;
    }

    public virtual void TakeDamage(float damage, bool crit)
    {
        DpsMeterData(damage, crit);
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

   
