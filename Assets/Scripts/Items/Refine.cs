using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refine : MonoBehaviour
{
    public int RefineLevel;
    private float RefineDamageMultiplier = 1.5f;
    private float RefineCritChanceMultiplier = 5f;
    private float RefineCritDamageMultiplier = .1f;
    public float finalDamage;


    public void findRefineType(bool _dmg, bool _critChance, bool _critDamage, float damage)
    {
        if (_dmg == true)
        {
            UpgradeDamageBasedOnRefine(damage); 
        }
        if (_critChance == true)
        {
            ChangeCritChanceBasedOnRefine();
        }
        if (_critDamage == true)
        {
            ChangeCritDamageBasedOnRefine();
        }
        
    }
    private void UpgradeDamageBasedOnRefine(float damage) 
    {
        this.gameObject.GetComponent<Weapon>().damage = ChangeDamageBasedOnRefine(damage);
    }

    private void ChangeCritChanceBasedOnRefine()
    {

        if (RefineLevel == 0)
        {
            this.gameObject.GetComponent<Weapon>().CritMod = RefineCritChanceMultiplier;
        }
        else if (RefineLevel > 0)
        {
            this.gameObject.GetComponent<Weapon>().CritMod = (RefineLevel+1) * RefineCritChanceMultiplier;
        }
    }

    private void ChangeCritDamageBasedOnRefine()
    {
        //the number 2 is used since the base damage for a crit should be double the normal amount of damage
        if (RefineLevel == 0)
        {
            this.gameObject.GetComponent<Weapon>().CritDamageMod = 2;
        }
        else if (RefineLevel > 0)
        {
            this.gameObject.GetComponent<Weapon>().CritDamageMod = 2 + ((RefineLevel+1) * RefineCritDamageMultiplier);
        }
    }

    public void SetRefine(int _refine)
    {
        RefineLevel = _refine;
    }
    // Start is called before the first frame update
    public float ChangeDamageBasedOnRefine(float dmg) 
    {
        //TODO : Better match for damage, more balanced
        // DMG = Base damage from the weapon, this is sent from the weapn script
        // Refine Multiplier is how much each refine increases the dmg
        // Refine Level is how many times you have refined
        // final damage is used in the weapon script to deal damage
        

        if (RefineLevel == 0)
        {
            finalDamage = dmg;

        }
        else if (RefineLevel > 0)
        {
            finalDamage = dmg + (RefineLevel * RefineDamageMultiplier);
        }
        return finalDamage;
    }    
   
}
