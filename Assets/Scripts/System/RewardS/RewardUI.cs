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
    }

    public void PickReward(GameObject item)
    {
        string itemName = item.name.ToString();
        if (GameObject.Find(itemName) || GameObject.Find(item.name.ToString() + "(Clone)"))
        {
            //if (item.GetComponent<Weapon>() != null)
            //{
            //    Weapon tempScriptActivation = item.GetComponent<Weapon>();
            //    tempScriptActivation.Enhance();
            //}
            //TODO: enhance the item
            GameObject.Find(item.name.ToString()).GetComponent<Weapon>().Enhance();
           // item.GetComponent<Weapon>().Enhance();
           // Debug.Log("Refine!");
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

    public void OpenUI()
    {
        GetRewardsList();
        this.gameObject.SetActive(true);
        
        if(Time.timeScale != 0)
        {
            Time.timeScale = 0;
        }
    }

    public void CloseUI()
    {
        ResetRewardList();
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
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
    }

    public void ResetRewardList()
    {
        rewards.Clear();
    }



}
