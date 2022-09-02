using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Items : MonoBehaviour
{
    public float SynergyA, SynergyB;

    public int enhancement;
    public int maxEnhance = 10;
    public virtual void Enhance()
    {

        if (enhancement < maxEnhance)
        {
            //Debug.Log("Enhanced!");
            //enhancement++;
            //this.gameObject.GetComponent<Refine>().SetRefine(enhancement);
        }

    }
}
