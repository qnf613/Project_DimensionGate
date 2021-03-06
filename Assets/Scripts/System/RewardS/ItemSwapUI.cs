using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ItemSwapUI : MonoBehaviour
{
    public ItemSwapButton[] Buttons;
    public TextMeshProUGUI[] texts;
    public Image[] sprites;
    public bool isForWeapon;
    public GameObject newItemToAdd;
    [SerializeField] private List<GameObject> tempList;
    private GameObject weaponList;
    private GameObject artifactList;

    public RewardSystem rs;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < Buttons.Length; i++)
        {
            Buttons[i] = Buttons[i].GetComponent<ItemSwapButton>();
        }
        for (int i = 0; i < Buttons.Length; i++)
        {
            texts[i] = texts[i].GetComponent<TextMeshProUGUI>();
        }
        rs = rs.GetComponent<RewardSystem>();
    }

    public void GetListOfOption()
    {
        tempList.Clear();
        if (isForWeapon)
        {
            weaponList = GameObject.Find("Weapons");
            foreach (Transform items in weaponList.transform)
            {
                tempList.Add(items.gameObject);
            }

            for (int i = 0; i < Buttons.Length; i++)
            {

                Buttons[i].assignedOption = tempList[i];
                texts[i].text = tempList[i].name.ToString();
                sprites[i].sprite = tempList[i].transform.Find("IconStore").GetComponent<SpriteRenderer>().sprite;
                
                
            }

        }

        else
        {
            artifactList = GameObject.Find("Artifacts");
            foreach (Transform items in artifactList.transform)
            {
                tempList.Add(items.gameObject);
            }

            for (int i = 0; i < Buttons.Length; i++)
            {
                Buttons[i].assignedOption = tempList[i];
                texts[i].text = tempList[i].name.ToString();
                sprites[i].sprite = tempList[i].transform.Find("IconStore").GetComponent<SpriteRenderer>().sprite;
            }
        }
    }

    public void SwapItem(GameObject removeThisOne)
    {
        removeThisOne = GameObject.Find(removeThisOne.name.ToString());
        if (removeThisOne.name == removeThisOne.name.ToString() || removeThisOne.name == removeThisOne.name.ToString() + "(Clone)")
        {
            //removeThisOne.SetActive(false);
            Destroy(removeThisOne);

            if (isForWeapon)
            {
                newItemToAdd = Instantiate(newItemToAdd, weaponList.transform);
                newItemToAdd.name = newItemToAdd.name.Replace("(Clone)", "");
            }
            else
            {
                newItemToAdd = Instantiate(newItemToAdd, weaponList.transform);
                newItemToAdd.name = newItemToAdd.name.Replace("(Clone)", "");
            }
        }
        CloseUI();
    }

    public void GetNewItem(GameObject itemToAdd)
    {
        newItemToAdd = itemToAdd;
    }

    public void CloseUI()
    {
        rs.CheckEquipments();
        this.gameObject.SetActive(false);
        Time.timeScale = 1;
    }

}
