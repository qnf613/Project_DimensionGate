using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


//public enum InventoryState { Sword, inactive };
public class InventorySystem : MonoBehaviour
{
    public List<GameObject> activeInventory;
    public List<GameObject> inactiveInventory;
    public InventoryUI iu;
    public GameObject IUI;
    // Start is called before the first frame update
    void Start()
    {
        inactiveInventory = Resources.LoadAll<GameObject>("Prefabs/Items").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!IUI.activeInHierarchy)
            {
                iu.OpenUI();
            }
            else if(IUI.activeInHierarchy)
            {
                iu.CloseUI();
            }
        }
    }
}
