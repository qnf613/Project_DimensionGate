using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ArtifactEquipped { yes, no };
public class Artifact : Items
{
    protected string aName;
    public string aDescription;
    public string descrptionTest = "";
    public ArtifactEquipped ae;
    [SerializeField] protected Camera cam;
    public AudioClip artifactSound;
    public float volume = 0.50f;

    protected Artifact()
    {
        aName = "";
        aDescription = "";
        enhancement = 0;
        ae = ArtifactEquipped.yes;
       
    }
    protected void Start()
    {
        cam = Camera.main;
    }

    protected virtual void Update()
    {
        switch (ae)
        {
            case ArtifactEquipped.yes:
                CheckCamera();
                break;
            case ArtifactEquipped.no:
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

    public override void Enhance()
    {

        if (enhancement < maxEnhance)
        {
            Debug.Log("Enhanced!");
            enhancement++;
            //this.gameObject.GetComponent<Refine>().SetRefine(enhancement);
            //ApplyEnhancement();
        }

    }
    //protected virtual void ApplyEnhancement()
    //{
    //    this.gameObject.GetComponent<Refine>().findRefineType(refineDamage, RefineCritChance, RefineCritDamage, damage);
    //}

}
