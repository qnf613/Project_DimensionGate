using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossUIManager : MonoBehaviour
{

    public string bossName;

    BossHealthUI bossHealthBar;
    DamageSystem enemyStats;

    private void Awake()
    {
        bossHealthBar = FindObjectOfType<BossHealthUI>();
        enemyStats = GetComponent<DamageSystem>();
    }


    private void Start()
    {
        bossHealthBar.SetBossName(bossName);
        bossHealthBar.SetBossMaxHealth(enemyStats.MaxHealth);
        bossHealthBar.SetUIHealthBarToActive();
    }

    public void UpdateBossHealth(float currentHealth)
    {
        bossHealthBar.SetBossCurrentHealth(currentHealth);
    }


}
