using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : PickUp
{
    public GameObject rsManager;
    public RewardSystem rs;
    public GameObject rUI;
    public RewardUI ru;
    public List<GameObject> equippedItemList;
    // Start is called before the first frame update
    void Start()
    {
        rsManager = GameObject.Find("RewardManager");
        rs = rsManager.GetComponent<RewardSystem>();
        rUI = GameObject.Find("UI-FollowCam").transform.Find("RewardPick").gameObject;
        ru = rUI.GetComponent<RewardUI>();
        //foreach (GameObject ei in )
        //{

        //}
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected override void PickedUp()
    {
        rs.MakeRewardList();
        ru.GetRewardsList();
        ru.OpenUI();
        //base.PickedUp();
    }
}
