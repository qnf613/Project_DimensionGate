using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum WeaponEquipped {yes, no};
public class Weapon : MonoBehaviour
{
    protected string name;
    protected string description;
    protected float damage;
    protected float atkspeed;
    protected float range;
    protected WeaponEquipped we;

    protected float lastShot = 0f;
    protected Vector3 targetPosition;
    public Camera cam;

    protected Weapon()
    {
        name = "";
        description = "";
        damage = 0;
        atkspeed = 0;
        range = 0;
        
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
