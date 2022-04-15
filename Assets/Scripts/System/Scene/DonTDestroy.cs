using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DonTDestroy : MonoBehaviour
{
    [SerializeField] private bool dontDestroyAdded = false;
    [SerializeField] private bool newSceneLoading = false;
    [SerializeField] private bool inStage = false;
    [SerializeField] private int levelData;
    [SerializeField] private int expData;
    [SerializeField] private int maxXpData;
    [SerializeField] private ClearCondition cc;
    // [SerializeField] private List<GameObject> tempList;
    // [SerializeField] private List<GameObject> WeaponList;
    // [SerializeField] private List<GameObject> ArtifactList;
    [SerializeField] private GameObject weapons;
    [SerializeField] private GameObject tempTest;
    [SerializeField] private GameObject artifacts;
    [SerializeField] private Transform inventory;
    void Awake()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Destroy it when it is in main menu
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;

        if (sceneName == "Loading" || sceneName == "Loading2" || sceneName == "Loading3")
        {
            inStage = false;
            newSceneLoading = true;
        }

        if (sceneName == "MainMenu" && dontDestroyAdded)
        {
            Destroy(this.gameObject);
            dontDestroyAdded = false;
        }

        else if (sceneName != "MainMenu" && !dontDestroyAdded)
        {
            DontDestroyOnLoad(this.gameObject);
            dontDestroyAdded = true;
        }

        else if (sceneName != "MainMenu" && (sceneName != "Loading" || sceneName != "Loading2" || sceneName != "Loading3"))
        {
            inStage = true;
            if(!newSceneLoading)
            {
                inventory = GameObject.Find("Inventory").transform;
                Instantiate(tempTest, inventory);
                weapons.name = "Weapons";
                Instantiate(artifacts, inventory);
                weapons.name = "Artifacts";
                newSceneLoading = false;
            }
            
            //cc = GameObject.Find("ClearManager").GetComponent<ClearCondition>();

            if(inStage)
            {
                newSceneLoading = false;
                weapons = GameObject.Find("Weapons");
                tempTest = weapons;
                artifacts = GameObject.Find("Artifacts");     
                levelData = GameObject.Find("LevelManager").GetComponent<LevelSystem>().level;
                expData = GameObject.Find("LevelManager").GetComponent<LevelSystem>().exp;
                maxXpData = GameObject.Find("LevelManager").GetComponent<LevelSystem>().expToLevelUp;

            }
            
            
        }

        
    }

}
