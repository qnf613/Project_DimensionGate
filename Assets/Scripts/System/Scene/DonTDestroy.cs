using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DonTDestroy : MonoBehaviour
{
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //Destroy it when it is in main menu
        Scene currentScene = SceneManager.GetActiveScene();
        string sceneName = currentScene.name;
        
        if (sceneName == "MainMenu")
        {
            Destroy(this.gameObject);
        }

        else if (sceneName != "MainMenu")
        {
            DontDestroyOnLoad(this.gameObject);
        }

    }

}
