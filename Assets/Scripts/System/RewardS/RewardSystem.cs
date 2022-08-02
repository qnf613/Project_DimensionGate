using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> commonItemList;
    [SerializeField] private List<GameObject> rareItemList;
    [SerializeField] private List<GameObject> epicItemList;
    [SerializeField] private List<GameObject> legendaryItemList;
    [SerializeField] private List<GameObject> tempList;
    [SerializeField] private List<GameObject> tempCommonList;
    [SerializeField] private List<GameObject> tempRareList;
    [SerializeField] private List<GameObject> tempEpicList;
    [SerializeField] private List<GameObject> tempLegendaryList;
    [SerializeField] private List<GameObject> equippedList;
    public List<GameObject> rewardsList;
    public GameObject equippedItems;
    public int weaponCount = 0;
    public int maxWeaponNums = 0;
    public int artifactCount = 0;
    public int maxArtifactNums = 0;
    public bool weaponFull = false;
    public bool artifactFull = false;
    public GameObject SwapWeaponUI;
    public GameObject SwapArtifactUI;

    int longCountRandomtest;
    public void Awake()
    {
        commonItemList = Resources.LoadAll<GameObject>("Prefabs/Items/Common").ToList();
        rareItemList = Resources.LoadAll<GameObject>("Prefabs/Items/Rare").ToList();
        epicItemList = Resources.LoadAll<GameObject>("Prefabs/Items.Epic").ToList();
        legendaryItemList = Resources.LoadAll<GameObject>("Prefabs/Items/Legendary").ToList();
    }
    // Start is called before the first frame update
    public void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        equippedItems = GameObject.Find("Inventory");
    }

    public void MakeRewardList()
    {
        CheckEquipments();

        //Make options depending on what player already has
        tempList.Clear();
        tempList = new List<GameObject>(equippedList);

        int choosenItemNum;
        //Player has only 1 item
        if (equippedList.LongCount() == 1)
        {
            for (int i = 0; i < 3; i++)
            {
                rewardsList.Add(tempList[0]);
            }
            tempList.Clear();
        }

        //Player has 2 items
        else if (equippedList.LongCount() == 2)
        {
            for (int i = 0; i < 3; i++)
            {
                choosenItemNum = (int)Random.Range(0, tempList.LongCount());
                rewardsList.Add(tempList[choosenItemNum]);
                if (i >= 1)
                {
                    tempList.RemoveAt(choosenItemNum);
                }
            }
            tempList.Clear();
        }

        //Player has more than 3 items
        else if (equippedList.LongCount() > 2)
        {
            for (int i = 0; i < 3; i++)
            {
                choosenItemNum = (int)Random.Range(0, tempList.LongCount());
                rewardsList.Add(tempList[choosenItemNum]);
                tempList.RemoveAt(choosenItemNum);
            }
            tempList.Clear();
        }
    }

    public void MakeLevelUpRewardList()
    {        
        CheckEquipments();

        //Make Temparary List for each Rarities 
        tempLegendaryList = new List<GameObject>(legendaryItemList);
        tempEpicList = new List<GameObject>(epicItemList);
        tempRareList = new List<GameObject>(rareItemList);
        tempCommonList = new List<GameObject>(commonItemList);

        int rarityRoll;
        int choosenItemNum;
        //Make 3 options from each rarity list + each rarity items have different possibility to get 
        for (int i = 0; i < 3; i++)
        {
            rarityRoll = (int)Random.Range(1, 101);

            if (rarityRoll < 6)
            {
                Debug.Log("Legendary!!");
                choosenItemNum = (int)Random.Range(0, tempLegendaryList.LongCount());
                rewardsList.Add(tempLegendaryList[choosenItemNum]);
                tempLegendaryList.RemoveAt(choosenItemNum);
            }

            else if (rarityRoll >= 6 && rarityRoll < 16)
            {
                Debug.Log("Epic!");
                choosenItemNum = (int)Random.Range(0, tempEpicList.LongCount());
                rewardsList.Add(tempEpicList[choosenItemNum]);
                tempEpicList.RemoveAt(choosenItemNum);
            }

            else if (rarityRoll >= 16 && rarityRoll < 41)
            {
                Debug.Log("Rare");
                choosenItemNum = (int)Random.Range(0, tempRareList.LongCount());
                rewardsList.Add(tempRareList[choosenItemNum]);
                tempRareList.RemoveAt(choosenItemNum);
            }

            else if (rarityRoll >= 41)
            {
                Debug.Log("Common..");
                choosenItemNum = (int)Random.Range(0, tempCommonList.LongCount());
                rewardsList.Add(tempCommonList[choosenItemNum]);
                tempCommonList.RemoveAt(choosenItemNum);
            }

        }
    }

    public void CheckEquipments()
    {
        equippedList.Clear();
        weaponCount = 0;
        artifactCount = 0;
        foreach (Transform TypeOfItems in equippedItems.transform)
        {
            foreach (Transform items in TypeOfItems.transform)
            {
                if (items.tag == "Weapon")
                {
                    weaponCount++;
                    if (weaponCount >= maxWeaponNums)
                    {
                        weaponFull = true;
                    }
                    else
                    {
                        weaponFull = false;
                    }
                }
                else if (items.tag == "Artifact")
                {
                    artifactCount++;
                    if (artifactCount >= maxArtifactNums)
                    {
                        artifactFull = true;
                    }
                    else
                    {
                        artifactFull = false;
                    }
                }

                items.name = items.name.Replace("(Clone)", "");
                equippedList.Add(items.gameObject);
            }
        }
    }

    public void OpenSwapWeaponUI(GameObject newItem)
    {
        Time.timeScale = 0;
        SwapWeaponUI.GetComponent<ItemSwapUI>().GetNewItem(newItem);
        SwapWeaponUI.GetComponent<ItemSwapUI>().GetListOfOption();
        SwapWeaponUI.SetActive(true);
    }

    public void OpenSwapArtifactUI(GameObject newItem)
    {
        Time.timeScale = 0;
        SwapArtifactUI.GetComponent<ItemSwapUI>().GetNewItem(newItem);
        SwapArtifactUI.GetComponent<ItemSwapUI>().GetListOfOption();
        SwapArtifactUI.SetActive(true);
    }

}
