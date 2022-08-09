using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;


//public enum InventoryState { Sword, inactive };
public class InventorySystem : MonoBehaviour
{
    public InventoryUI iu;
    public GameObject IUI;
    public GameObject rUI;
    public GameObject HpBar;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!IUI.activeInHierarchy)
            {
                Time.timeScale = 0;
                iu.OpenUI();
                HpBar.SetActive(false);
            }
            else if(IUI.activeInHierarchy)
            {
                iu.CloseUI();
                HpBar.SetActive(true);
                if (rUI.activeInHierarchy == true)
                {

                }
                else
                {
                    Time.timeScale = 1;
                }
                
            }
        }
    }
}
