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
    public Image[] sprites;
    public List<GameObject> rewards;
    [SerializeField] private GameObject weaponInventory;
    [SerializeField] private GameObject artifactInventory;
    List<GameObject> gs = new List<GameObject>();

    public TextMeshProUGUI rewardMessage;

    public GameObject HammerSlot1, HammerSlot2, HammerSlot3;

    public GameObject XPBar;
    public LevelSystem ls;
    public bool isChestPickUp;
    // Start is called before the first frame update
    public void Start()
    {
        weaponInventory = GameObject.Find("Weapons");
        artifactInventory = GameObject.Find("Artifacts");
        rs = rs.GetComponent<RewardSystem>();
        rb1 = rb1.GetComponent<RewardButton>();
        rb2 = rb2.GetComponent<RewardButton>();
        rb3 = rb3.GetComponent<RewardButton>();
        for (int i = 0; i < 3; i++)
        {
            texts[i] = texts[i].GetComponent<TextMeshProUGUI>();
        }
        ls = ls.GetComponent<LevelSystem>();
        isChestPickUp = false;
        rewardMessage.GetComponent<TextMeshProUGUI>();
    }
    
    public void PickReward(GameObject item)
    {
        GameObject newItem;
        string itemName = item.name.ToString();
        if (GameObject.Find(itemName) || GameObject.Find(item.name.ToString() + "(Clone)"))
        {     
            GameObject.Find(item.name.ToString()).GetComponent<Weapon>().Enhance();
        }
        else if(!GameObject.Find(itemName))
        {
            if(item.gameObject.tag == "Weapon")
            {
                newItem = Instantiate(item, weaponInventory.transform);
                newItem.name = newItem.name.Replace("(Clone)", "");
            }
            if (item.gameObject.tag == "Artifact")
            {
                newItem = Instantiate(item, artifactInventory.transform);
                newItem.name = newItem.name.Replace("(Clone)", "");
            }
        }

         // This disables the upgrade hammer icons
        CloseUI();
    }
    void DisableHammers()
    {
        HammerSlot1.SetActive(false);
        HammerSlot2.SetActive(false);
        HammerSlot3.SetActive(false);
    }
    public void OpenUI()
    {
        GetRewardsList();
        this.gameObject.SetActive(true);
        hideXPBar();
        if (ls.lvUp)
        {
            rewardMessage.text = "LEVEL UP!";
            rewardMessage.fontSize = 100;
        }
        if (isChestPickUp)
        {
            rewardMessage.text = "What are you going to pick from the chest?";
            rewardMessage.fontSize = 40;
        }
        if (Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
    }

    public void CloseUI()
    {
        DisableHammers();
        ResetRewardList();
        this.gameObject.SetActive(false);
        displayXPBar();
        if (ls.lvUp)
        {
            ls.lvUp = false;
            rewardMessage.text = "";
        }
        if (isChestPickUp)
        {
            isChestPickUp = false;
            rewardMessage.text = "";
        }
        if (Time.timeScale != 1) 
        {
            Time.timeScale = 1;
        }
    }

    public void displayXPBar()
    {
        XPBar.SetActive(true);
    }
    public void hideXPBar()
    {
        XPBar.SetActive(false);
    }


    public void GetRewardsList()
    {
        rewards = rs.rewardsList;
        AssignRewards();
    }

    public void AssignRewards()
    {
        rb1.assignedItem = rewards[0];
        texts[0].text = rb1.assignedItem.name;
        sprites[0].sprite = rewards[0].transform.Find("IconStore").GetComponent<SpriteRenderer>().sprite;

        rb2.assignedItem = rewards[1];
        texts[1].text = rb2.assignedItem.name;
        sprites[1].sprite = rewards[1].transform.Find("IconStore").GetComponent<SpriteRenderer>().sprite;

        rb3.assignedItem = rewards[2];
        texts[2].text = rb3.assignedItem.name;
        sprites[2].sprite = rewards[2].transform.Find("IconStore").GetComponent<SpriteRenderer>().sprite;

        CheckForDuplicate(rb1, rb2, rb3);
    }
    void CheckForDuplicate(RewardButton _rb1, RewardButton _rb2, RewardButton _rb3)
    {

        //This checks for duplicates and enables the upgrade hammer icon    
        if (GameObject.Find(_rb1.assignedItem.name.ToString()))
        {
            HammerSlot1.SetActive(true);
        }
        if (GameObject.Find(_rb2.assignedItem.name.ToString()))
        {
            HammerSlot2.SetActive(true);
        }
        if (GameObject.Find(_rb3.assignedItem.name.ToString()))
        {
            HammerSlot3.SetActive(true);
        }

    }
    public void ResetRewardList()
    {
        rewards.Clear();
    }



}
