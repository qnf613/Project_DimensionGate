using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ManageScene : MonoBehaviour
{
    [SerializeField] protected GameObject player;
    [SerializeField] protected string load_scene;
    [SerializeField] private Button button;

    private void Start()
    {
        button.onClick.AddListener(LoadOnClick);
      
    }

   private void LoadOnClick()
    {
        StartCoroutine(LoadScene());
        Debug.Log("you clicked the button");
    }


    protected IEnumerator LoadScene()
    {
        if(Time.timeScale != 1f){
            Time.timeScale = 1f;
        }
        // sets current scene to whatever the current scene is
        Scene currentScene = SceneManager.GetActiveScene();
        Debug.Log("current scene is " + currentScene);

        //starts loading next scene in the background
        AsyncOperation asyncLoadScene = SceneManager.LoadSceneAsync(load_scene, LoadSceneMode.Additive);
        Debug.Log("loading scene...");

        //waits for the scene to be loaded to continue
        while(!asyncLoadScene.isDone)
        {
            yield return null;
        }

        //checks for if you're on a scene without the player object (aka main menu)
        if (player == null)
        {
            //just unloads the scene)
            SceneManager.UnloadSceneAsync(currentScene);
            Debug.Log("no player, unloading scene");
        }

       
        else 
        {
            //moves player to new scene and unloads previous scene
            SceneManager.MoveGameObjectToScene(player, SceneManager.GetSceneByName(load_scene));
            SceneManager.UnloadSceneAsync(currentScene);
            Debug.Log("player noticed, moving player and loading scene.");
        }
    }

}
