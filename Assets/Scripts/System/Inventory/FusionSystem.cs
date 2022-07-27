using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class FusionSystem : MonoBehaviour
{
    //[SerializeField] private List<GameObject> tempList;
    [SerializeField] private List<GameObject> equippedList;
    [SerializeField] private List<GameObject> synergyList;
    public GameObject equippedItems;
    // Start is called before the first frame update
    void Start()
    {
        equippedItems = GameObject.Find("Inventory");
        synergyList = Resources.LoadAll<GameObject>("Prefabs/Items/Synergy").ToList();
    }

    // Update is called once per frame
    void Update()
    {
        //tempList.Clear();
        //tempList = new List<GameObject>(equippedList);
    }


    public void CheckEquiped()
    {
        equippedList.Clear();
        foreach (Transform TypeOfItems in equippedItems.transform)
        {
            foreach (Transform items in TypeOfItems.transform)
            {
                items.name = items.name.Replace("(Clone)", "");
                equippedList.Add(items.gameObject);
            }
        }
        CompareSynergyNum();
    }

    public void CompareSynergyNum()
    {
        for (int i = 0; i < equippedList.Count - 1; i++)
        {
            for (int j = i + 1; j < equippedList.Count; j++)
            {
                if (equippedList[i].gameObject.GetComponent<Items>().SynergyA == equippedList[j].gameObject.GetComponent<Items>().SynergyA)
                {
                    if (equippedList[i].gameObject.GetComponent<Items>().SynergyA != 0)
                    {
                        Debug.Log("Synergy Number A Matched!");
                    }
                    
                }

                else if (equippedList[i].gameObject.GetComponent<Items>().SynergyB == equippedList[j].gameObject.GetComponent<Items>().SynergyB)
                {
                    if (equippedList[i].gameObject.GetComponent<Items>().SynergyB != 0)
                    {
                        Debug.Log("Synergy Number B Matched!");
                    }
                }
            }
            
        }

    }


}
