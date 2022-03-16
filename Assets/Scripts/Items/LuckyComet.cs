using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyComet : Weapon
{

    [SerializeField] private string name = "Lucky Comet";
    [SerializeField] private string description = "Lucky this comet decided to orbit around you";
    [SerializeField] private float rotationspeed = 30;
    
    // Start is called before the first frame update
    void Start()
    {
        this.wName = name;
        this.wDescription = description;
       
    }

    // Update is called once per frame
    protected override void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationspeed) * Time.deltaTime);
    }
    protected override void Shoot()
    {
    }
    protected override float CalcFinalDamage()
    {
        if (crit == true)
        {
            finalDamageNumber = this.gameObject.GetComponentInParent<Refine>().ChangeDamageBasedOnRefine(damage) * CritDamageMod;
        }
        else if (crit == false)
        {
            finalDamageNumber = this.gameObject.GetComponentInParent<Refine>().ChangeDamageBasedOnRefine(damage);
        }
        return finalDamageNumber;
    }
}
