using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


//public enum InventoryState { Sword, inactive };
public class InventorySystem : MonoBehaviour
{
   public List<GameObject> activeInventory;
   public List<GameObject> inactiveInventory;
    // Start is called before the first frame update
    void Start()
    {
        inactiveInventory = Resources.LoadAll<GameObject>("Prefabs/Items").ToList();
    }

    // Update is called once per frame
    void Update()
    {
     
    }
}
