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
    private bool ingre1Ready = false;
    private bool infre2Ready = false;
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
            fu.warn.text = "Error: You Already Own This Item";
            fu.DisplayWarning();
        }

        else if (!GameObject.Find(teampNewItemName) || !GameObject.Find(teampNewItemName + "(Clone)"))
        {
            checkRequiredItemLevel();
            if (ingre1Ready && infre2Ready)
            {
                removeIngredients();
                fu.AddItem(assignedItem);
                CloseFuseUI();
                bigInvetoryUI.CloseUI();
            }
            else
            {
                fu.warn.text = "Error: Some materials' enhancement levels have not reached the max level";
                fu.DisplayWarning();
            }

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

    public void checkRequiredItemLevel()
    {
        ingre1Ready = false;
        infre2Ready = false;
        if (GameObject.Find(assignedItem.GetComponent<Synergy>().ingredient1.ToString()).GetComponent<Items>().enhancement == GameObject.Find(assignedItem.GetComponent<Synergy>().ingredient1.ToString()).GetComponent<Items>().maxEnhance)
        {
            ingre1Ready = true;
        }
        if (GameObject.Find(assignedItem.GetComponent<Synergy>().ingredient2.ToString()).GetComponent<Items>().enhancement == GameObject.Find(assignedItem.GetComponent<Synergy>().ingredient2.ToString()).GetComponent<Items>().maxEnhance)
        {
            infre2Ready = true;
        }
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
