using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{

    [SerializeField] private float health = 0f;

    [SerializeField] private float maxHealth = 100;
    [SerializeField] private Slider healthSlider;
    [SerializeField] private Text healthValue;
    [SerializeField] private SpriteFlash flashEffect;
    [SerializeField] private AudioClip playerdamageSFX;
    [SerializeField] private float playerdamagevolume = 0.50f;

    void Start()
    {
        health = maxHealth;
        healthSlider.maxValue = maxHealth;
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

        AudioSource.PlayClipAtPoint(playerdamageSFX, transform.position, playerdamagevolume);
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
}
