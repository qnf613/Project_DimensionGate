using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : PickUp
{
    public GameObject rsManager;
    public RewardSystem rs;
    public GameObject rUI;
    public RewardUI ru;
    // Start is called before the first frame update
    void Start()
    {
        rsManager = GameObject.Find("RewardManager");
        rs = rsManager.GetComponent<RewardSystem>();
        rUI = GameObject.Find("UI-FollowCam").transform.Find("RewardPick").gameObject;
        ru = rUI.GetComponent<RewardUI>();
    }

    protected override void PickedUp()
    {
        rs.MakeRewardList();
        ru.GetRewardsList();
        ru.OpenUI();
        //base.PickedUp();
    }
}
