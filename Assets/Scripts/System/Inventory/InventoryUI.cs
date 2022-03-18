using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventoryUI : MonoBehaviour
{
    public GameObject inventoryUI;
    [SerializeField] private GameObject[] Slots;
    [SerializeField] private GameObject slotPrefab;
    [SerializeField] private List<GameObject> itemsInUI;
    [SerializeField] private int maxCapacity = 10;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (inventoryUI.activeInHierarchy)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                AddItemSlot();
            }
            else if (Input.GetKeyDown(KeyCode.Backspace))
            {
                
            }
        }
    }

    public void OpenUI()
    {
        inventoryUI.SetActive(true);
        //if (Time.timeScale != 0)
        //{
        //    Time.timeScale = 0;
        //}
    }

    public void CloseUI()
    {
        inventoryUI.SetActive(false);
        //Time.timeScale = 1;
    }

    public void AddItemSlot()
    {
        Instantiate(slotPrefab, GameObject.Find("Slots").transform);
        GetAllItemsInInventory();
    }

    public void GetAllItemsInInventory()
    {
        itemsInUI = new List<GameObject>();
        foreach (Transform item in GameObject.Find("Slots").GetComponentsInChildren<Transform>())
        {
            if (item.name == "Slot" || item.name == "Slot(Clone)")
            {
                itemsInUI.Add(item.gameObject);
            }
        }
    }
}
