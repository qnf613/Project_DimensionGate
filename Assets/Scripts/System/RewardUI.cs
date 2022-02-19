using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class RewardUI : MonoBehaviour
{
    public RewardSystem rs;
    public RewardButton rb1;
    public RewardButton rb2;
    public RewardButton rb3;
    public List<GameObject> rewards;
    public GameObject weaponInventory;
    public GameObject artifactInventory;
    public GameObject rewardUI;

    // Start is called before the first frame update
    void Start()
    {
        rs = rs.GetComponent<RewardSystem>();
        rb1 = rb1.GetComponent<RewardButton>();
        rb2 = rb2.GetComponent<RewardButton>();
        rb3 = rb3.GetComponent<RewardButton>();
    }

    // Update is called once per frame
    void Update()
    {
        GetRewardsList();
    }

    public void PickReward(GameObject item)
    {
        if (item.activeInHierarchy)
        {
            //TODO: enhance the item
        }
        else if(!item.activeInHierarchy)
        {
            if(item.gameObject.tag == "Weapon")
            {
            Instantiate(item, weaponInventory.transform);
            }
            if(item.gameObject.tag == "Artifact")
            {
            Instantiate(item, artifactInventory.transform);
            }
        }
        CloseUI();
    }

    public void OpenUI(){
        rewardUI.SetActive(true);
        GetRewardsList();
    }

    public void CloseUI(){
        rewardUI.SetActive(false);
        ResetRewardList();
    }

    public void GetRewardsList()
    {
        rewards = rs.rewardsList;
        AssignRewards();
    }

    public void AssignRewards(){
        rb1.assignedItem = rewards[0];
        rb2.assignedItem = rewards[1];
        rb3.assignedItem = rewards[2];
    }

    public void ResetRewardList()
    {
        rewards.Clear();
    }
}
