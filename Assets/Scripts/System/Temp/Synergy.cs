using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synergy : MonoBehaviour
{
    // Start is called before the first frame update

    
    public void CompareAW(Items a, Items b)
    {
        if (a.SynergyA == b.SynergyA || a.SynergyB == b.SynergyB)
        {
            //fuse and make spawn in the new item in the player inventory
        }
    }
   
}
