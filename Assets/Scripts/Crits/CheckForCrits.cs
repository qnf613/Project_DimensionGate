using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckForCrits : MonoBehaviour
{
    public float randomNumber;
    public bool crit;

    public bool CheckCrits(float _gcr, float critMod) //_gcr = global crit rate
    {
        CritCheck(GetRandomNumber(), _gcr, critMod);

        return crit;
    }
    public float GetRandomNumber() 
    { 
    randomNumber = Random.Range(0, 100);
        return randomNumber;
    }

    void CritCheck(float _randomNumber, float _gcr, float critMod)
    {
        if (_randomNumber <= _gcr + critMod)
        {
            crit = true;
           // Debug.Log("crit");
        }
        else
        {
            crit = false;
        }
    }
}
