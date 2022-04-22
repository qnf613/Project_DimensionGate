using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DonTDestroy : MonoBehaviour
{
    [SerializeField] private bool dontDestroyAdded = false;
    [SerializeField] private bool newSceneLoading = false;
    [SerializeField] public static bool inStage;
    [SerializeField] private ClearCondition cc;
    [SerializeField] private GameObject inventory;
    [SerializeField] private LevelSystem levelSystem;
    [SerializeField] private int levelData;
    [SerializeField] private int currentXPData;
    [SerializeField] private int maxXPData;

    // Update is called once per frame
    void Update()
    {
        if(cc == null && inStage)
        {
            cc = GameObject.Find("ClearManager").GetComponent<ClearCondition>();
        }

        if (cc.sc == stageCleared.yes && !dontDestroyAdded)
        {
            Debug.Log("Stage clear detected - DontDestroy");
            if (inventory == null)
            {
                inventory = GameObject.Find("Inventory");
            }
            if (levelSystem == null)
            {
                levelSystem = GameObject.Find("LevelManager").GetComponent<LevelSystem>();
            }
            
            inventory.transform.parent = gameObject.transform;

            levelData = levelSystem.level;
            currentXPData = levelSystem.exp;
            maxXPData = levelSystem.expToLevelUp;
            
            DontDestroyOnLoad(gameObject);

            dontDestroyAdded = true;
        }

        else if (cc.sc == stageCleared.yet && dontDestroyAdded)
        {
            if (inventory == null)
            {
                inventory = GameObject.Find("Inventory");
            }
            if (levelSystem == null)
            {
                levelSystem = GameObject.Find("LevelManager").GetComponent<LevelSystem>();
            }

            inventory.transform.parent = GameObject.Find("Player").transform;
            inventory.transform.position = GameObject.Find("Player").transform.position;
            inventory.SetActive(true);

            levelSystem.GetComponent<LevelSystem>().level = levelData;
            levelSystem.GetComponent<LevelSystem>().exp = currentXPData;
            levelSystem.GetComponent<LevelSystem>().expToLevelUp = maxXPData;
            
            dontDestroyAdded = false;
        }

        if (!inStage)
        {
            inventory.SetActive(false);
        }

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            gameObject.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        }
    }

}
