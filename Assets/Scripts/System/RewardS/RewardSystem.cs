using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    [SerializeField] private List<GameObject> allItemList;
    [SerializeField] private List<GameObject> tempList;
    [SerializeField] private List<GameObject> equippedList;
    public List<GameObject> rewardsList;
    public GameObject Chest; /*debugging purpose*/
    public GameObject equippedItems;
    public int weaponCount = 0;
    private int artifactCount = 0;
    public bool weaponFull = false;
    public bool artifactFull = false;

    public GameObject SwapWeaponUI;
    public GameObject SwapArtifactUI;
    public void Awake()
    {
        allItemList = Resources.LoadAll<GameObject>("Prefabs/Items").ToList(); //get all items and add it to list
    }
    // Start is called before the first frame update
    public void Start()
    {
        equippedItems = GameObject.Find("Inventory");
    }

    // Update is called once per frame
    public void Update()
    {

       
    }

    public void MakeRewardList()
    {
        CheckEquipments();
        
        //Make options depending on what player already has
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
        }
    }

    public void MakeLevelUpRewardList()
    {        
        CheckEquipments();
        //Make options from all items
        tempList = new List<GameObject>(allItemList);
        int choosenItemNum;
        for (int i = 0; i < 3; i++)
        {
            choosenItemNum = (int)Random.Range(0, tempList.LongCount());
            rewardsList.Add(tempList[choosenItemNum]);
            tempList.RemoveAt(choosenItemNum);
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
                    if (weaponCount >= 3)
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
                    if (artifactCount >= 5)
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
