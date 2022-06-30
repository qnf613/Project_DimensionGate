using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Synergy : MonoBehaviour
{
    // Start is called before the first frame update

    
    public void CompareAW(Artifact a, Weapon w)
    {
        if (a.SynergyA == w.SynergyA || a.SynergyB == w.SynergyB)
        {
            //fuse and make spawn in the new item in the player inventory
        }
    }
    public void CompareAA(Artifact a1, Artifact a2)
    {
        if (a1.SynergyA == a2.SynergyA || a1.SynergyB == a2.SynergyB)
        {
            //fuse and make spawn in the new item in the player inventory
        }
    }
    public void CompareWW(Weapon w1, Weapon w2)
    {
        if (w1.SynergyA == w2.SynergyA || w1.SynergyB == w2.SynergyB)
        {
            //fuse and make spawn in the new item in the player inventory
        }
    }
}
