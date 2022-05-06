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

    private void Update()
    {
        if (Time.timeScale == 0)
        {
            BossName.enabled = false;
        }
        else if (Time.timeScale == 1)
        {
            BossName.enabled = true;
        }
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
        BossName.gameObject.SetActive(true);
        slider.gameObject.SetActive(true);
    }

    public void SetHealthBarToInactive()
    {
        BossName.gameObject.SetActive(false);
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