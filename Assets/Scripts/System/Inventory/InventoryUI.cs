using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private GameObject[] Slots;
    [SerializeField] private List<GameObject> teampItemList;
    public GameObject rUI;
    public bool isWeaponSlots;
    public bool isArtifactSlots;
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
        Time.timeScale = 0;
        this.gameObject.SetActive(true);
        GetAllWeapons();
        GetAllArtifacts();
    }

    public void CloseUI()
    {
        this.gameObject.SetActive(false);
        if (!rUI.activeInHierarchy)
        {
            Time.timeScale = 1;
        }
    }

    public void GetAllArtifacts()
    {
        if (isArtifactSlots)
        {
            //reset the List that store 'previous' item list
            teampItemList = new List<GameObject>();
            //find all of items that tagged with "Artifact" and add each of them into this itemList
            foreach (Transform item in GameObject.Find("Artifacts").GetComponentsInChildren<Transform>())
            {
                if (item.tag == "Artifact")
                {
                    teampItemList.Add(item.gameObject);
                }
            }
            //assign each item's icon into each assigned slot of inventory UI
            for (int i = 0; i < teampItemList.Count; i++)
            {
                Slots[i].transform.Find("ItemImage").GetComponent<Image>().sprite = teampItemList[i].transform.Find("IconStore").GetComponent<SpriteRenderer>().sprite;
                Slots[i].transform.Find("ItemImage").GetComponent<Image>().color = teampItemList[i].transform.Find("IconStore").GetComponent<SpriteRenderer>().color;
            }
        }
    }

    public void GetAllWeapons()
    {
        if (isWeaponSlots)
        {
            //reset the List that store 'previous' item list
            teampItemList = new List<GameObject>();
            //find all of items that tagged with "Artifact" and add each of them into this itemList
            foreach (Transform item in GameObject.Find("Weapons").GetComponentsInChildren<Transform>())
            {
                if (item.tag == "Weapon")
                {
                    teampItemList.Add(item.gameObject);
                }
            }
            //assign each item's icon into each assigned slot of inventory UI
            for (int i = 0; i < teampItemList.Count; i++)
            {
                Slots[i].transform.Find("ItemImage").GetComponent<Image>().sprite = teampItemList[i].transform.Find("IconStore").GetComponent<SpriteRenderer>().sprite;
                Slots[i].transform.Find("ItemImage").GetComponent<Image>().color = teampItemList[i].transform.Find("IconStore").GetComponent<SpriteRenderer>().color;

                //Finds the slot's TextCoponent in the Text Gameobject. And sets it to the outcome of GetAllWeaponEnhancementLevels(); Read the other coment below to understand more
                Slots[i].transform.Find("Text").GetComponent<Text>().text = GetAllWeaponEnhancementLevels(Slots[i].GetComponent<Weapon>());
            }
        }

    }
    public string GetAllWeaponEnhancementLevels(Weapon wep) // This takes in the Refine level from the weapon and sets it translates to string so we can display item level
    {
        RefineLevel = "+" + wep.enhancement.ToString();
        return RefineLevel;
    }
}
 