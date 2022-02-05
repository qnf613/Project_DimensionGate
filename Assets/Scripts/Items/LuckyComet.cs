using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyComet : Weapon
{
    public float rotationspeed = 30;
    // Start is called before the first frame update
    void Start()
    {
        this.name = "Lucky Comet";
        this.description = "Lucky this comet decided to orbit around you";
        this.damage = 50;        
        we = WeaponEquipped.yes;
    }

    // Update is called once per frame
    protected override void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationspeed) * Time.deltaTime);
    }
}
