using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseUIOpener : MonoBehaviour
{
    public GameObject fuseUI;
    public GameObject fsManager;
    public FusionSystem fs;
    // Start is called before the first frame update
    void Start()
    {
        if (fuseUI == null)
        {
            fuseUI = GameObject.Find("FuseUI");
        }
        fsManager = GameObject.Find("SynergyManager");
        fs = fsManager.GetComponent<FusionSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OpenFuse()
    {
        fuseUI.SetActive(true);
        fs.CheckEquiped();
    }
}
