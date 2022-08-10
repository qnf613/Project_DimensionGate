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
        string teampNewItemName = assignedItem.name.ToString();
        //check this items already existing or not
        if (GameObject.Find(teampNewItemName) || GameObject.Find(teampNewItemName + "(Clone)"))
        {
            fu.DisplayWarning();
        }

        else if (!GameObject.Find(teampNewItemName) || !GameObject.Find(teampNewItemName + "(Clone)"))
        {
            removeIngredients();
            fu.AddItem(assignedItem);
            CloseFuseUI();
            bigInvetoryUI.CloseUI();
        }
    }

    public void NextOption()
    {
        if (fu.SItems.Count > 1)
        {
            fu.currentSyItemListOrderNum += 1;
            if (fu.currentSyItemListOrderNum >= fu.SItems.Count)
            {
                fu.currentSyItemListOrderNum = 0;
            }
            fu.ApplyCurrentOptionToButton();
        }
        if (fu.warning.activeInHierarchy == true)
        {
            fu.warning.SetActive(false);
        }
    }

    public void PreviousOption()
    {
        if (fu.SItems.Count > 1)
        {
            fu.currentSyItemListOrderNum -= 1;
            if (fu.currentSyItemListOrderNum < 0)
            {
                fu.currentSyItemListOrderNum = fu.SItems.Count - 1;
            }
            fu.ApplyCurrentOptionToButton();
        }
        if (fu.warning.activeInHierarchy == true)
        {
            fu.warning.SetActive(false);
        }
    }

    public void removeIngredients()
    {
        Destroy(GameObject.Find(assignedItem.GetComponent<Synergy>().ingredient1));
        Destroy(GameObject.Find(assignedItem.GetComponent<Synergy>().ingredient2));
    }

    public void CloseFuseUI()
    {
        if (fu.warning.activeInHierarchy == true)
        {
            fu.warning.SetActive(false);
        }
        fuseUI.SetActive(false);
    }
}
