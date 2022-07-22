using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckierComet : Weapon
{
    [SerializeField] private string name = "Luckier Comet";
    [SerializeField] private string description = "It looks like the comet is deploying caltrops to help you";
    [SerializeField] private float rotationspeed = 30;
    public GameObject secondComet;
    public GameObject thirdComet;
    public GameObject forthComet;
    
    // Start is called before the first frame update
    void Start()
    {
        this.wName = name;
        this.wDescription = description;

    }

    // Update is called once per frame
    protected void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationspeed) * Time.deltaTime);

        if (this.enhancement >= 3)
        {
            secondComet.SetActive(true);

        }
        if (this.enhancement >= 6)
        {
            thirdComet.SetActive(true);
        }
        if (this.enhancement >= 9)
        {
            forthComet.SetActive(true);
        }
        
    }
   
    public override float CalcCritDamage()
    {
        CheckIfCrit();
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
