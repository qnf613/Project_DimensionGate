using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyComet : Weapon
{
    [SerializeField] private string name = "Lucky Comet";
    [SerializeField] private string description = "Lucky this comet decided to orbit around you";
    [SerializeField] private int damage = 50;
    [SerializeField] private float rotationspeed = 30;
    // Start is called before the first frame update
    void Start()
    {
        this.wName = name;
        this.wDescription = description;
        this.wDamage = damage;        
        we = WeaponEquipped.yes;
    }

    // Update is called once per frame
    protected override void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationspeed) * Time.deltaTime);
    }
}
