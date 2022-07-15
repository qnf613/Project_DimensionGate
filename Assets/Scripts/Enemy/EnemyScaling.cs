using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScaling : MonoBehaviour
{
    public FloatHpVariable defaultHP;

    public float maxHealth;
    private float modify;
    //Choosing the HP multiplier
    [SerializeField] public float hpMultiplier;
    public DamageSystem enemyMaxHealth;


    void Start()
    {
        enemyMaxHealth.newMaxHealth = defaultHP.defaultHP;
        enemyMaxHealth.MaxHealth = defaultHP.defaultHP;
        maxHealth = enemyMaxHealth.MaxHealth;
        InvokeRepeating("healthScale", 60f, 60f);
    }


    public void healthScale()
    {
        // Get max HP again from damage system script
        maxHealth = enemyMaxHealth.newMaxHealth;
        // change max HP with with multiplier
        modify = maxHealth * hpMultiplier;
        // change new maxHealth from damage system script
        enemyMaxHealth.newMaxHealth = modify;

        Debug.Log("Change health");
    }




}
