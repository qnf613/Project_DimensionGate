using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSystem : MonoBehaviour
{
    //level related
    public int level;
    public int exp;
    public int expToLevelUp;
    //rewarding related
    public GameObject rsManager;
    public RewardSystem rs;
    public GameObject rUI;
    public RewardUI ru;
    // Start is called before the first frame update
    void Start()
    {
        level = 1;
        exp = 0;
        expToLevelUp = 10;
        
        rsManager = GameObject.Find("RewardManager");
        rs = rsManager.GetComponent<RewardSystem>();
        rUI = GameObject.Find("UI-FollowCam").transform.Find("RewardPick").gameObject;
        ru = rUI.GetComponent<RewardUI>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if (exp >= expToLevelUp)
        {
            LevelUp();
        }
       
    }

    public void LevelUp()
    {
        level++;
        exp -= expToLevelUp;
        expToLevelUp = level * 10 + 20;
        rs.MakeLevelUpRewardList();
        ru.GetRewardsList();
        ru.OpenUI();
    }

    public void AddExp(int amount)
    {
        exp += amount;
        Debug.Log("Current exp: " + exp);
    }

}
