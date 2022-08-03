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
    // Start is called before the first frame update
    void Start()
    {
        synergyInventory = GameObject.Find("Synergys");
        fs = fs.GetComponent<FusionSystem>();
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
        }

        //if (this.gameObject.activeInHierarchy)
        //{
        //    GetPossibleItemsList();
        //}
    }

    public void AddItem(GameObject item)
    {
        GameObject newItem;
        newItem = Instantiate(item, synergyInventory.transform);
        newItem.name = newItem.name.Replace("(Clone)", "");
        CloseUI();
    }

    public void CloseUI()
    {
        ResetRewardList();
        this.gameObject.SetActive(false);
    }

    public void GetPossibleItemsList()
    {
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
        texts[0].text = SItems[currentSyItemListOrderNum].GetComponent<Synergy>().ingredient2;
        sprites[0].sprite = SItems[currentSyItemListOrderNum].transform.Find("Ing2Icon").GetComponent<SpriteRenderer>().sprite;
        //SygergyItem's name & icon
        texts[0].text = fb.assignedItem.name;
        sprites[0].sprite = SItems[currentSyItemListOrderNum].transform.Find("IconStore").GetComponent<SpriteRenderer>().sprite;
    }

    public void ResetRewardList()
    {
        SItems.Clear();
    }
}
