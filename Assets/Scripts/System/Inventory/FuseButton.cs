using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FuseButton : MonoBehaviour
{
    public FusionSystem fs;
    public GameObject fuseUI;
    public GameObject assignedItem;
    public InventoryUI bigInvetoryUI;
    public bool checking;
    // Start is called before the first frame update
    void Start()
    {
        checking = false;
        if (fuseUI == null)
        {
            fuseUI = GameObject.Find("FuseUI");
        }
        if (fs == null)
        {
            fs = GameObject.Find("SynergyManager").GetComponent<FusionSystem>();
        }
        if (bigInvetoryUI == null)
        {
            bigInvetoryUI = GameObject.Find("BigUI").GetComponent<InventoryUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fuse()
    {
        Debug.Log("This button (" + this.gameObject.name + ") has been clicked");
        //TODO: add synergyweapon


        CloseFuseUI();
        bigInvetoryUI.CloseUI();
    }

    public void CloseFuseUI()
    {
        fuseUI.SetActive(false);
    }
}
