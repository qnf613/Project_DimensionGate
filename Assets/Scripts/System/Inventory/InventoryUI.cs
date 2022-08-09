using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject[] Slots;
    [SerializeField] private List<GameObject> tempItemList;
    public bool isWeaponSlots;
    public bool isArtifactSlots;
    public bool isSynergySlots;
    public bool isBigUI;
    public string RefineLevel;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (DonTDestroy.inStage)
        {
            GetAllWeapons();
            GetAllArtifacts();
        }
        //debug
        if (Input.GetKeyDown(KeyCode.I))
        {
            GetAllWeapons();
        }
        if (Input.GetKeyDown(KeyCode.O))
        {
            GetAllArtifacts();
        }
    }


    public void OpenUI()
    {
        this.gameObject.SetActive(true);
        GetAllArtifacts();
        GetAllWeapons();
    }

    public void CloseUI()
    {
        this.gameObject.SetActive(false);
    }


    public void GetAllWeapons()
    {
        if (isWeaponSlots)
        {
            //reset the List that store 'previous' item list
            tempItemList = new List<GameObject>();
            //find all of items that tagged with "Weapon" and add each of them into this itemList
            foreach (Transform item in GameObject.Find("Weapons").GetComponentsInChildren<Transform>())
            {
                if (item.tag == "Weapon")
                {
                    tempItemList.Add(item.gameObject);
                }
            }
            //assign each item's icon into each assigned slot of inventory UI
            for (int i = 0; i < tempItemList.Count; i++)
            {
                Slots[i].transform.Find("ItemImage").GetComponent<Image>().sprite = tempItemList[i].transform.Find("IconStore").GetComponent<SpriteRenderer>().sprite;
                Slots[i].transform.Find("ItemImage").GetComponent<Image>().color = tempItemList[i].transform.Find("IconStore").GetComponent<SpriteRenderer>().color;
                //Finds the slot's TextCoponent in the Text Gameobject. It should read/display 2 different things.
                //1. Get items' enhancement level and display it with GetAllWeaponEnhancementLevels().
                //2. Get items' description.
                //Read the other coment below to understand more
                if (tempItemList[i].GetComponent<Weapon>() != null)
                {
                    Slots[i].transform.Find("Text").GetComponent<TextMeshProUGUI>().text = GetAllWeaponEnhancementLevels(tempItemList[i].GetComponent<Weapon>());
                    if (isBigUI)
                    {
                        Slots[i].GetComponent<MouseOver>().itemEquiped = true;
                        Slots[i].transform.Find("DescriptionUI").transform.Find("Description").GetComponent<TextMeshProUGUI>().text = tempItemList[i].GetComponent<Weapon>().wDescription;
                        //Debug.Log(tempItemList[i].GetComponent<Weapon>().SynergyA);
                    }
                }
            }
        }

    }

    public void GetAllArtifacts()
    {
        if (isArtifactSlots)
        {
            //reset the List that store 'previous' item list
            tempItemList = new List<GameObject>();
            //find all of items that tagged with "Artifact" and add each of them into this itemList
            foreach (Transform item in GameObject.Find("Artifacts").GetComponentsInChildren<Transform>())
            {
                if (item.tag == "Artifact")
                {
                    tempItemList.Add(item.gameObject);
                }
            }
            //assign each item's icon into each assigned slot of inventory UI
            for (int i = 0; i < tempItemList.Count; i++)
            {

                Slots[i].transform.Find("ItemImage").GetComponent<Image>().sprite = tempItemList[i].transform.Find("IconStore").GetComponent<SpriteRenderer>().sprite;
                Slots[i].transform.Find("ItemImage").GetComponent<Image>().color = tempItemList[i].transform.Find("IconStore").GetComponent<SpriteRenderer>().color;
                //** TODO **
                //Finds the slot's TextCoponent in the Text Gameobject. It should read/display 2 different things.
                //1. Get items' enhancement level and display it with GetAllArtifactEnhancementLevels().
                //2. Get items' description.
                //Read the other coment below to understand more
                //if (teampItemList[i].GetComponent<Artifact>() != null)
                //{
                //    Slots[i].transform.Find("Text").GetComponent<TextMeshProUGUI>().text = GetAllArtifactEnhancementLevels(teampItemList[i].GetComponent<Artifact>());
                //    if (isBigUI)
                //    {
                //        Slots[i].transform.Find("DescriptionUI").transform.Find("Description").GetComponent<TextMeshProUGUI>().text = teampItemList[i].GetComponent<Weapon>().wDescription;
                //    }
                //}
            }
        }
    }

    public void GetAllSynergies()
    {
        //TODO: same thing as getalliweapons/artifacts
        //if (isSynergySlots)
        //{
        //    //reset the List that store 'previous' item list
        //    tempItemList = new List<GameObject>();
        //    //find all of items that tagged with "Weapon" and add each of them into this itemList
        //    foreach (Transform item in GameObject.Find("Synergies").GetComponentsInChildren<Transform>())
        //    {
        //        if (item.tag == "Synergy")
        //        {
        //            tempItemList.Add(item.gameObject);
        //        }
        //    }
        //    //assign each item's icon into each assigned slot of inventory UI
        //    for (int i = 0; i < tempItemList.Count; i++)
        //    {
        //        Slots[i].transform.Find("ItemImage").GetComponent<Image>().sprite = tempItemList[i].transform.Find("IconStore").GetComponent<SpriteRenderer>().sprite;
        //        Slots[i].transform.Find("ItemImage").GetComponent<Image>().color = tempItemList[i].transform.Find("IconStore").GetComponent<SpriteRenderer>().color;
        //        //Finds the slot's TextCoponent in the Text Gameobject. It should read/display 2 different things.
        //        //1. Get items' enhancement level and display it with GetAllWeaponEnhancementLevels().
        //        //2. Get items' description.
        //        //Read the other coment below to understand more
        //        if (tempItemList[i].GetComponent<Weapon>() != null)
        //        {
        //            Slots[i].transform.Find("Text").GetComponent<TextMeshProUGUI>().text = GetAllWeaponEnhancementLevels(tempItemList[i].GetComponent<Weapon>());
        //            if (isBigUI)
        //            {
        //                Slots[i].GetComponent<MouseOver>().itemEquiped = true;
        //                Slots[i].transform.Find("DescriptionUI").transform.Find("Description").GetComponent<TextMeshProUGUI>().text = tempItemList[i].GetComponent<Weapon>().wDescription;
        //                //Debug.Log(tempItemList[i].GetComponent<Weapon>().SynergyA);
        //            }
        //        }
        //    }
        //}
    }


    public string GetAllWeaponEnhancementLevels(Weapon wep) // This takes in the Refine level from the weapon and sets it translates to string so we can display item level
    {
        if (wep.enhancement == 0)
        {
            RefineLevel = "";
        }
        else if (wep.enhancement == 10)
        {
            RefineLevel = "+X";
        }
        else
        {
            RefineLevel = "+" + wep.enhancement + "";
        }
           
        return RefineLevel;
    }
}
 