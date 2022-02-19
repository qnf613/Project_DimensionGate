using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponEquipped {yes, no};
public class Weapon : MonoBehaviour
{
    protected string wName;
    protected string wDescription;
    protected float wDamage;
    protected float wAtkspeed;
    protected float wRange;
    protected int enhancement;
    protected int maxEnhance;
    public WeaponEquipped we;

    protected float lastShot = 0f;
    protected Vector3 targetPosition;
    [SerializeField]protected Camera cam;

    protected Weapon()
    {
        
        wName = "";
        wDescription = "";
        wDamage = 0;
        wAtkspeed = 0;
        wRange = 0;
        enhancement = 1;
        we = WeaponEquipped.yes;
        
    }
    protected void Start()
    {
        cam = Camera.main;
    }
    // Update is called once per frame
    protected virtual void Update()
    {
        switch (we)
        {
            case WeaponEquipped.yes:
                CheckCamera();
                Aim();
                Shoot();
                break;
            case WeaponEquipped.no:
                break;
            default:
                break;
        }
    }
    void CheckCamera()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }
   
    protected virtual void Aim()
    {
        
    }
    protected virtual void Shoot()
    {
       
    }

    public void Enhance()
    {
        if (enhancement < maxEnhance)
        {
            enhancement++;
        }
        enhancement ++;
    }

    protected virtual void IncreaseStats()
    {

    }
}
