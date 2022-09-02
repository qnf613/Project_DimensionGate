using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class FuseUI : MonoBehaviour
{
    public FusionSystem fs;
    public FuseButton fb;
    public TextMeshProUGUI[] texts;
    public Image[] sprites;
    public List<GameObject> SItems;
    public int currentSyItemListOrderNum;
    [SerializeField] private GameObject synergyInventory;
    public GameObject warning;
    public TextMeshProUGUI warn;

    public int synergyCount;
    // Start is called before the first frame update
    void Start()
    {
        synergyInventory = GameObject.Find("Synergies");
        if (fs == null)
        {
            fs = GameObject.Find("SynergyManager").GetComponent<FusionSystem>();
        }
        fb = fb.GetComponent<FuseButton>();
        for (int i = 0; i < 3; i++)
        {
            texts[i] = texts[i].GetComponent<TextMeshProUGUI>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Tab))
        {
            CloseUI();
            synergyCount = fs.possibleSynergies.Count;
        }
    }

    public void AddItem(GameObject item)
    {
        GameObject newItem;
        string itemName = item.name.ToString();
        if (!GameObject.Find(itemName))
        {
            if (item.gameObject.tag == "Synergy")
            {
                newItem = Instantiate(item, synergyInventory.transform);
                newItem.name = newItem.name.Replace("(Clone)", "");
                CloseUI();
            }
        }
    }

    public void CloseUI()
    {
        ResetSynergyList();
        this.gameObject.SetActive(false);
        if (Time.timeScale != 1)
        {
            Time.timeScale = 1;
        }
    }

    public void GetPossibleItemsList()
    {
        SItems = new List<GameObject>();
        SItems = fs.possibleSynergies;
        currentSyItemListOrderNum = 0;
        ApplyCurrentOptionToButton();
        
    }

    public void ApplyCurrentOptionToButton()
    {
        fb.assignedItem = SItems[currentSyItemListOrderNum];
        //ingredient 1's name & icon
        texts[0].text = SItems[currentSyItemListOrderNum].GetComponent<Synergy>().ingredient1;
        sprites[0].sprite = SItems[currentSyItemListOrderNum].transform.Find("Ing1Icon").GetComponent<SpriteRenderer>().sprite;
        //ingredient 2's name & icon
        texts[1].text = SItems[currentSyItemListOrderNum].GetComponent<Synergy>().ingredient2;
        sprites[1].sprite = SItems[currentSyItemListOrderNum].transform.Find("Ing2Icon").GetComponent<SpriteRenderer>().sprite;
        //SygergyItem's name & icon
        texts[2].text = fb.assignedItem.name;
        sprites[2].sprite = SItems[currentSyItemListOrderNum].transform.Find("IconStore").GetComponent<SpriteRenderer>().sprite;
    }

    public void ResetSynergyList()
    {
        SItems.Clear();
    }

    public void DisplayWarning()
    {
        warning.SetActive(true);
    }
}
