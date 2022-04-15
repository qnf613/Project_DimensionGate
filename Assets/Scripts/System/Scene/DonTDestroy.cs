using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DonTDestroy : MonoBehaviour
{
    [SerializeField] private bool dontDestroyAdded;
    private bool turnOnOnce;
    void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Destroy it when it is in main menu
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        
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

        else if (sceneName != "MainMenu" && sceneName != "Loading")
        {
            if (!turnOnOnce)
            {
                if (gameObject.transform.Find("Player") != null)
                {
                    gameObject.transform.Find("Player").gameObject.SetActive(true);
                }
                turnOnOnce = true;
            }
            
        }

        if (sceneName == "Loading")
        {
            if (gameObject.transform.Find("Player") != null)
            {
                gameObject.transform.Find("Player").gameObject.SetActive(false);
                if (gameObject.transform.Find("Player").transform.position != new Vector3(0, 0, 0))
                {
                    this.transform.position = new Vector3(0, 0, 0);
                }
            }
            turnOnOnce = false;

        }
    }

}
