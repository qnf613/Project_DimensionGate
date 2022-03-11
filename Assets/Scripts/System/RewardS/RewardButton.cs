using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardButton : MonoBehaviour
{
    public RewardSystem rs;
    public RewardUI ru;
    public GameObject assignedItem;
    // Start is called before the first frame update
    void Start()
    {
        rs = rs.GetComponent<RewardSystem>();/*rs.GetComponent<RewardSystem>();*/
        ru = ru.GetComponent<RewardUI>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void PickThisOption(){
        ru.PickReward(assignedItem);
    }
}
