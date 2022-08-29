using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DonTDestroy : MonoBehaviour
{
    [SerializeField] private bool dontDestroyAdded = false;
    [SerializeField] private bool newSceneLoading = false;
    [SerializeField] private bool pauseUION = false;
    [SerializeField] public static bool inStage;
    [SerializeField] private ClearCondition cc;
    [SerializeField] private GameObject inventory;
    [SerializeField] private LevelSystem levelSystem;
    [SerializeField] private int levelData;
    [SerializeField] private int currentXPData;
    [SerializeField] private int maxXPData;
    [SerializeField] GameObject pauseMenu;


    // Update is called once per frame
    void Update()
    {
        if(cc == null && inStage)
        {
            cc = GameObject.Find("ClearManager").GetComponent<ClearCondition>();
        }

        if (cc.sc == stageCleared.yes && !dontDestroyAdded)
        {
            if (inventory == null)
            {
                inventory = GameObject.Find("Inventory");
            }
            if (levelSystem == null)
            {
                levelSystem = GameObject.Find("LevelManager").GetComponent<LevelSystem>();
            }

            if (pauseMenu == null)
            {
                pauseMenu = GameObject.Find("puaseUI");
            }

            inventory.transform.parent = gameObject.transform;

            levelData = levelSystem.level;
            currentXPData = levelSystem.exp;
            maxXPData = levelSystem.expToLevelUp;
            
            DontDestroyOnLoad(gameObject);

            dontDestroyAdded = true;
        }



        else if (cc.sc == stageCleared.yet)
        {
            if (inventory == null)
            {
                inventory = GameObject.Find("Inventory");
            }

            if(dontDestroyAdded)
            {
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

            if (pauseMenu == null)
            {
                pauseMenu = GameObject.Find("puaseUI");
            }

            else if (pauseMenu != null)
            {
                //if (Input.GetKeyDown(KeyCode.Escape))
                //{
                //    if (pauseUION)
                //    {
                //        if (Time.timeScale == 0)
                //        {
                //            Time.timeScale = 1;
                //        }
                //        pauseMenu.SetActive(false);
                //    }
                //    if (!pauseUION)
                //    {
                //        Time.timeScale = 0;
                //        pauseMenu.SetActive(true);
                //    }
                //}
            }
        }

        if (!inStage && cc.sc == stageCleared.yes)
        {
            inventory.SetActive(false);
        }

        if (GameObject.FindGameObjectWithTag("Player") != null)
        {
            gameObject.transform.position = GameObject.FindGameObjectWithTag("Player").transform.position;
        }

        if (cc.sc == stageCleared.over || SceneManager.GetActiveScene().name == "Ending")
        {
            Destroy(GameObject.Find(this.gameObject.name));
        }
    }

}
