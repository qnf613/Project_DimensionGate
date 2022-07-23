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


    private void Awake()
    {
        // Reset health with defaultHP variable
        enemyMaxHealth.newMaxHealth = defaultHP.defaultHP;
        enemyMaxHealth.MaxHealth = defaultHP.defaultHP;
    }
    void Start()
    {

        //Get MaxHealth from prefab
        maxHealth = enemyMaxHealth.MaxHealth;
        // call healthscale every 60(change to whatever) seconds.
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
