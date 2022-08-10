using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseUIOpener : MonoBehaviour
{
    public GameObject fuseUI;
    public FuseUI fu;
    public GameObject fsManager;
    public FusionSystem fs;
    // Start is called before the first frame update
    void Start()
    {
        if (fuseUI == null)
        {
            fuseUI = GameObject.Find("FuseUI");
        }
        fu = fuseUI.GetComponent<FuseUI>();
        fsManager = GameObject.Find("SynergyManager");
        fs = fsManager.GetComponent<FusionSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenFuse()
    {
        fs.CheckEquiped();
        if (fs.possibleSynergies.Count != 0)
        {
            fu.GetPossibleItemsList();
            fuseUI.SetActive(true);
        }
    }
}
