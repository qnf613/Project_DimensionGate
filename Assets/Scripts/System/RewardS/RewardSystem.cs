using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class RewardSystem : MonoBehaviour
{
    public List<GameObject> allItemList;
    public List<GameObject> tempList;
    public List<GameObject> rewardsList;
    public GameObject ChestDemo;

    public void Awake()
    {
        allItemList = Resources.LoadAll<GameObject>("Prefabs/Items").ToList();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(ChestDemo, transform.position, transform.rotation);
        }
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!GameObject.Find("Player"))
            {
                Debug.Log("Player is not here");
            }
            else
            {
                Debug.Log("Player is here");
            }
        }
    }

    public void MakeRewardList()
    {
        tempList = new List<GameObject>(allItemList);
        int choosenItemNum;
        for (int i = 0; i < 3; i++)
        {
            choosenItemNum = (int)Random.Range(0, tempList.LongCount());
            Debug.Log("The number is " + choosenItemNum);
            rewardsList.Add(tempList[choosenItemNum]);
            tempList.RemoveAt(choosenItemNum);
        }
    }
}
