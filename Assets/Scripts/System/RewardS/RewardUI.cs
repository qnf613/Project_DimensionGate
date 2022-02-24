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
    public TextMeshProUGUI[] texts;
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
        for (int i = 0; i < 3; i++)
        {
            texts[i] = texts[i].GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PickReward(GameObject item)
    {
        string itemName = item.name.ToString() + "(Clone)";
        //Debug.Log("You Picked " + item.name.ToString());
        if (GameObject.Find(itemName))
        {
            //TODO: enhance the item
            Debug.Log("Refine!");
        }
        else if(!GameObject.Find(itemName))
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
        GetRewardsList();
        rewardUI.SetActive(true);
        Time.timeScale = 0;
    }

    public void CloseUI(){
        ResetRewardList();
        rewardUI.SetActive(false);
        Time.timeScale = 1;
    }

    public void GetRewardsList()
    {
        rewards = rs.rewardsList;
        AssignRewards();
    }

    public void AssignRewards(){
        rb1.assignedItem = rewards[0];
        texts[0].text = rb1.assignedItem.name;

        rb2.assignedItem = rewards[1];
        texts[1].text = rb2.assignedItem.name;

        rb3.assignedItem = rewards[2];
        texts[2].text = rb3.assignedItem.name;
    }

    public void ResetRewardList()
    {
        rewards.Clear();
    }
}
