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
    protected WeaponEquipped we;

    protected float lastShot = 0f;
    protected Vector3 targetPosition;
    public Camera cam;

    protected Weapon()
    {
        wName = "";
        wDescription = "";
        wDamage = 0;
        wAtkspeed = 0;
        wRange = 0;
        
        we = WeaponEquipped.no;
        
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        switch (we)
        {
            case WeaponEquipped.yes:
                Aim();
                Shoot();
                break;
            case WeaponEquipped.no:
                break;
            default:
                break;
        }
    }

   
    protected virtual void Aim()
    {
        
    }
    protected virtual void Shoot()
    {
       
    }
}