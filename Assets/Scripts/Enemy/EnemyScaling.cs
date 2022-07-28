using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScaling : MonoBehaviour
{
    public FloatHpVariable defaultHP;
    public IntXpVariable defaultXP;


    public DamageSystem enemyMaxHealth;
    public ExpContainer enemyexp;


    public float maxHealth;
    private float hpModify;

    //Choosing the HP multiplier
    [SerializeField] public float hpMultiplier;
    [SerializeField] public int xpMultiplier;


    public int baseXp;
    private int xpModify;



    private void Awake()
    {
        // Reset health with defaultHP variable
        enemyMaxHealth.newMaxHealth = defaultHP.defaultHP;
        enemyMaxHealth.MaxHealth = defaultHP.defaultHP;

        if (enemyexp != null)
        {
            enemyexp.newExp = defaultXP.defaultXP;
        }

    }
    void Start()
    {

        //Get MaxHealth + base xp from prefab
        maxHealth = enemyMaxHealth.MaxHealth;
        if (enemyexp != null)
        {
            baseXp = enemyexp.exp;
        }

        // call healthscale + expscale every 60(change to whatever) seconds.
        InvokeRepeating("healthScale", 60f, 60f);
        InvokeRepeating("expScale", 120f, 120f);

    }


    public void healthScale()
    {
        // Get max HP again from damage system 
        maxHealth = enemyMaxHealth.newMaxHealth;
        // change max HP using multiplier
        hpModify = maxHealth * hpMultiplier;
        // change new maxHealth from damage system 
        enemyMaxHealth.newMaxHealth = hpModify;

        Debug.Log("Change health");
    }

    public void expScale()
    {
        // Get Base XP from EXP container 
        baseXp = enemyexp.exp;
        // change basexp using multiplier
        xpModify = baseXp * xpMultiplier;
        // change new max xp from EXP container
        enemyexp.newExp = xpModify;

    }




}
