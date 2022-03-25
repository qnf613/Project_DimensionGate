using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RewardButton : MonoBehaviour
{
    public RewardSystem rs;
    public RewardUI ru;
    public GameObject assignedItem;
    public InventoryUI iu;
    public bool checking;
    // Start is called before the first frame update
    void Start()
    {
        checking = false;
        rs = rs.GetComponent<RewardSystem>();/*rs.GetComponent<RewardSystem>();*/
        ru = ru.GetComponent<RewardUI>();
    }

    public void PickThisOption()
    {
        checking = true;
        string teampNewItemName = assignedItem.name.ToString();
        //check this items already existing or not
        if (GameObject.Find(teampNewItemName) || GameObject.Find(teampNewItemName + "(Clone)"))
        {
            //if item is exist already, get again to upgrade that item
            ru.PickReward(assignedItem); // PickRewrd() will take care of above description
            iu.GetAllWeapons();
        }

        else if(!GameObject.Find(teampNewItemName) || !GameObject.Find(teampNewItemName + "(Clone)"))
        {
            if (checking)
            {
                //if this item does not exists in inventory, check either its item type (weapon or artifact) is maximum capacity. If so, open up swap option UI
                if (assignedItem.tag == "Weapon")
                {
                    if (rs.weaponFull)
                    {
                        checking = false;
                        ru.CloseUI();
                        rs.OpenSwapWeaponUI(assignedItem);
                        
                    }
                    else
                    {
                        ru.PickReward(assignedItem);
                        iu.GetAllWeapons();
                    }
                }

                else if (assignedItem.tag == "Artifact")
                {
                    if (rs.artifactFull)
                    {
                        checking = false;
                        rs.OpenSwapArtifactUI(assignedItem);
                    }
                    else
                    {
                        ru.PickReward(assignedItem);
                        iu.GetAllWeapons();
                    }
                }
            }
            
        }
        
    }

    public void PickNothing()
    {
        //TO DO: give currency for upgrading items
        ru.CloseUI();
    }
}
