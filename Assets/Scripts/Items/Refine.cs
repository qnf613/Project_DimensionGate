using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Refine : MonoBehaviour
{
    public int RefineLevel;
    public float RefineMultiplier;
    public float finalDamage;
    // Start is called before the first frame update
    public float ChangeDamageBasedOnRefine(float dmg) 
    {
        //TODO : Better match for damage, more balanced
        // DMG = Base damage from the weapon, this is sent from the weapn script
        // Refine Multiplier is how much each refine increases the dmg
        // Refine Level is how many times you have refined
        // final damage is used in the weapon script to deal damage
        finalDamage = dmg + (RefineLevel * RefineMultiplier);

        return finalDamage;
    }    
    
}
