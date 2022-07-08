using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScaling : MonoBehaviour
{

    public float maxHealth;
    public float newMaxHealth;
    public float modify;
    public float modifyBack;
    //Choosing the HP multiplier
    public float hpMultiplier;
    public DamageSystem enemyMaxHealth;
    void Start()
    {
        //maxHealth = enemyMaxHealth.MaxHealth;
        modify = enemyMaxHealth.healthModifier;
        InvokeRepeating("healthScale", 60f, 60f);
    }


    public void healthScale()
    {
        // hp modifier is base 1 then multiply by what we want
        modifyBack = modify * hpMultiplier;
        // change the health modifier in the damage script.
        enemyMaxHealth.healthModifier = modifyBack;
        // change the base to the new multiplier
        modify = enemyMaxHealth.healthModifier;
        Debug.Log("Change health");

        //newMaxHealth = maxHealth * 1.05f;
        //enemyMaxHealth.MaxHealth = newMaxHealth;
        //healthReset();
    }

    public void healthReset()
    {
        maxHealth = newMaxHealth;
    }


}
