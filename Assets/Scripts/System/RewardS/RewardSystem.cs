using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    public List<GameObject> allItemList;
    public List<GameObject> tempList;
    public List<GameObject> equippedList;
    public List<GameObject> rewardsList;
    public GameObject Chest; /*debugging purpose*/
    public GameObject inventory;
    public int weaponCount;
    public int artifactCount;

    public void Awake()
    {
        allItemList = Resources.LoadAll<GameObject>("Prefabs/Items").ToList(); //get all items and add it to list
    }
    // Start is called before the first frame update
    void Start()
    {
        //only working with weapons for now, but should include artifacts later
        inventory = GameObject.Find("Inventory");
    }

    // Update is called once per frame
    void Update()
    {
        //debugging - get chset pick up
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(Chest, transform.position, transform.rotation);
        }
       
    }

    public void MakeRewardList()
    {
        //Make options depending on what player already has
        equippedList.Clear();
        foreach (Transform TypeOfItems in inventory.transform)
        {
            foreach (Transform items in TypeOfItems.transform)
            {
                if (items.tag == "Weapon")
                {
                    weaponCount++;
                }
                else if (items.tag == "Artifact")
                {
                    artifactCount++;
                }

                items.name = items.name.Replace("(Clone)", "");
                equippedList.Add(items.gameObject);
            }
        }

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


}
