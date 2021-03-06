using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FuseButton : MonoBehaviour
{
    public FusionSystem fs;
    public GameObject fuseUI;
    public FuseUI fu;
    public GameObject assignedItem;
    public InventoryUI bigInvetoryUI;
    // Start is called before the first frame update
    void Start()
    {
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
        fu = fuseUI.GetComponent<FuseUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FuseThisOption()
    {
        //TODO: add synergyweapon

        string teampNewItemName = assignedItem.name.ToString();
        //check this items already existing or not
        if (GameObject.Find(teampNewItemName) || GameObject.Find(teampNewItemName + "(Clone)"))
        {
            //if item is exist already, get again to upgrade that item
            fu.AddItem(assignedItem); // PickRewrd() will take care of above description
            bigInvetoryUI.GetAllSynergies();
        }

        else if (!GameObject.Find(teampNewItemName) || !GameObject.Find(teampNewItemName + "(Clone)"))
        {
            //if this item does not exists in inventory, get this item
            fu.AddItem(assignedItem);
            bigInvetoryUI.GetAllSynergies();
        }

        CloseFuseUI();
        bigInvetoryUI.CloseUI();
    }

    public void NextOption()
    {
        fu.currentSyItemListOrderNum += 1;
        if (fu.currentSyItemListOrderNum >= fu.SItems.Count)
        {
            fu.currentSyItemListOrderNum = 0;
        }
        fu.ApplyCurrentOptionToButton();
    }

    public void PreviousOption()
    {
        fu.currentSyItemListOrderNum -= 1;
        if (fu.currentSyItemListOrderNum < 0) 
        {
            fu.currentSyItemListOrderNum = fu.SItems.Count - 1;
        }
        fu.ApplyCurrentOptionToButton();
    }

    public void CloseFuseUI()
    {
        fuseUI.SetActive(false);
    }
}
