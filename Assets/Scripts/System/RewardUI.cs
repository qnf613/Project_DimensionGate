using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RewardUI : MonoBehaviour
{
    public RewardSystem rs;
    public List<GameObject> rewards;
    public GameObject pickedItem;
    public TextMeshPro[] OptionNames;
    public GameObject playersInventory;

    // Start is called before the first frame update
    void Start()
    {
        rs = rs.GetComponent<RewardSystem>();
    }

    // Update is called once per frame
    void Update()
    {
        GetRewardsList();
    }

    public void DisplayOption()
    {
        OptionNames[0].text = rewards[0].ToString();
        OptionNames[1].text = rewards[1].ToString();
        OptionNames[2].text = rewards[2].ToString();
    }

    public void Option1()
    {
        pickedItem = rewards[0];
        PickReward(pickedItem);
    }

    public void Option2()
    {
        pickedItem = rewards[1];
        PickReward(pickedItem);
    }

    public void Option3()
    {
        pickedItem = rewards[2];
        PickReward(pickedItem);
    }

    public void PickReward(GameObject item)
    {
        if (item.activeInHierarchy)
        {

        }
        else if(!item.activeInHierarchy)
        {
            Instantiate(item, playersInventory.transform);
        }

        ResetRewardList();
    }

    public void GetRewardsList()
    {
        rewards = rs.rewardsList;
    }

    public void ResetRewardList()
    {
        rewards.Clear();
    }
}
