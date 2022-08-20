using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DPSMeter : MonoBehaviour
{

    TMP_Text txt;
    float currentTime;
    float outofcombattimer, olddps;
    bool combatstatus = false;
    

    float DPS, totaldamage, CrRa, crits, notcrits;
    private void Start()
    {
        DPS = 0;
        CrRa = 0;
        crits = 0;
        notcrits = 0;
        totaldamage = 0;
        txt = this.gameObject.GetComponent<TMP_Text>();
        currentTime = 0;
        outofcombattimer = 10;
    }
    private void Update()
    {
        currentTime = currentTime + Time.deltaTime;
        
        DisplayTXT();

        if (outofcombattimer > 0)
        {
            outofcombattimer -= Time.deltaTime;
            if (outofcombattimer < 0)
            {
                combatstatus = false;
                ResetData();
            }
        }
    }
    public void ArrangeCalcs(float d, bool c)
    {
        combatstatus = true;
        outofcombattimer = 10;

        dpsW(d);
        CR(c);
        StartOutOfCombatTimer();
 
    }
    public void StartOutOfCombatTimer()
    {

        outofcombattimer = 10;
        currentTime = currentTime - Time.deltaTime;
        if (outofcombattimer < 0)
        {
            outofcombattimer = 10;
            ResetData();
        }
    }
    public float dpsW(float _d)
    {
        olddps = DPS;
        totaldamage += _d;
        DPS = totaldamage / currentTime;
        return DPS;
    }
    public float CR(bool _c)
    {
        
        if (_c == true)
        {
            crits++;
        }
        if (_c == false)
        {
            notcrits++;
        }
        CrRa = crits / (crits + notcrits) * 100;
        return CrRa;
    }
    public void DisplayTXT()
    {   
        txt.text = $"DPS: {DPS.ToString("0.00")}\n\n Crit Rate: {CrRa.ToString("0.00")}% \n\n Combat timer; {outofcombattimer.ToString("0.00")}"; 
    }
    
    private void ResetData()
    {
        totaldamage = 0;
        currentTime = 1;
        crits = 0;
        notcrits = 0;
        DPS = 0;
        CrRa = 0;
    }
}
