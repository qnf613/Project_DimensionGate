using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DonTDestroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
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

        //debugging - scene move
        if (Input.GetKeyDown(KeyCode.C))
        {
            SceneManager.LoadScene("Jin2(test Purpose)");
        }

    }

}
