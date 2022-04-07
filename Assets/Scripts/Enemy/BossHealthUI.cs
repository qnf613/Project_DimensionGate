using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class BossHealthUI : MonoBehaviour
{
    public TextMeshProUGUI BossName;
    public Slider slider;


    private void Awake()
    {
        slider = GetComponentInChildren<Slider>();
        BossName = GetComponentInChildren<TextMeshProUGUI>();
    }

    private void Start()
    {
        SetHealthBarToInactive();
    }
    public void SetBossName(string name)
    {
        BossName.text = name;
    }

    public void SetUIHealthBarToActive()
    {
        slider.gameObject.SetActive(true);
    }

    public void SetHealthBarToInactive()
    {
        slider.gameObject.SetActive(false);
    }

    public void SetBossMaxHealth(float MaxHealth)
    {
        slider.maxValue = MaxHealth;
        slider.value = MaxHealth;

    }
    public void SetBossCurrentHealth(float currentHealth)
    {
        slider.value = currentHealth;
    }

}