using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSwapButton : MonoBehaviour
{
    public ItemSwapUI su;
    public GameObject assignedOption;
    public InventoryUI iu;
    // Start is called before the first frame update
    void Start()
    {
        su = su.GetComponent<ItemSwapUI>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PickThisToSwap()
    {
        su.SwapItem(assignedOption);
        iu.GetAllWeapons();
    }
}
