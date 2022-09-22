using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerStats : MonoBehaviour
{
    //HP & DMG Taken
    public float health = 0f;
    public float maxHealth = 100;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Text healthValue;
    [SerializeField] private SpriteFlash flashEffect;
    [SerializeField] private AudioClip playerdamageSFX;
    [SerializeField] private float playerdamagevolume = 0.50f;
    //Movement Speed
    public float originalSpeed;
    public float maxSpeed;
    //Weapon Related Stats
    public float BaseDMG;      // as multifly *if 10% more dmg than 1.1f
    public float BaseCritRate; // as sum *if 10% more crit rate than 10
    public float BaseCritDMG;  // as sums of modifiers *if 10% more crit dmg than .1f
    //Status
    [SerializeField] private bool slowed = false;
    [SerializeField] private bool burning = false;
    [SerializeField] private float burntickSpeed = 1, lastTick;
    [SerializeField] private float burnstr;

    void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
        originalSpeed = maxSpeed;
    }

    public void Update()
    {
        if (burning == true)
        {
            DealTickDamage(burnstr);
        }

        if (maxSpeed < originalSpeed)
        {
            maxSpeed = originalSpeed;
        }
    }
    private void DealTickDamage(float str)
    {
        if (Time.time > burntickSpeed / 3 + lastTick)
        {
            UpdateHealth(str);
            lastTick = Time.time;
        }
    }

    public void UpdateHealth(float mod)
    {
        if (mod <0)
        {
            //This will do the flash indicator if the number which comes in is a negative number
            //This is here so only damaging numbers will cause a flash.
            flashEffect.Flash();
        }
        if (mod > 0)
        {
            //Healing effect here
        }

        if(playerdamageSFX != null)
        {
            AudioSource.PlayClipAtPoint(playerdamageSFX, transform.position, playerdamagevolume);
        }

        health += mod;

        if(health > maxHealth)
        {
            health = maxHealth;
        }
        else if(health<=0f)
        {
            health = 0f;
            healthSlider.value = health;
            Destroy(gameObject);

        }
    }

    private void OnGUI()
    {
        // Changing the time here will change how fast the the slider moves down when hit.
        float t = Time.deltaTime / .1f;
        healthSlider.value = Mathf.Lerp(healthSlider.value, health, t);
        
    }

    public virtual void ApplyStatusEffect(float status, float Strength, float duration)
    {
        if (Strength > 80)
        {
            Strength = 80;
        }
        if (status == 1 && slowed == false)
        {
            if (this.gameObject.GetComponent<Player>() != null)
            {
                slowed = true;
                Strength = 1 - Strength / 100;
                this.gameObject.GetComponent<Player>()._Speed *= Strength;
                

                Invoke("RemoveStatusEffectSlow", duration);
            }
        }
        if (status == 2 && burning == false)
        {
            burnstr = Strength;
            Invoke("RemoveStatusEffectBurn", duration);
            burning = true;
        }
    }

    private void RemoveStatusEffectBurn() { burning = false; }
    private void RemoveStatusEffectSlow()
    {

        this.gameObject.GetComponent<Player>()._Speed = maxSpeed;

        slowed = false;
    }

}
