using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;

public class Loading : MonoBehaviour
{
    public string sceneWillLoad;
    public List<string> scenes;

    public static GameObject DontDestroyOnLoad;
    public static LoadState ls;
    // Start is called before the first frame update
    void Start()
    {
       // sceneWillLoad = scenes[1];
       // SceneManager.LoadScene(sceneWillLoad);

    }
    public void SetUp()
    {
       
        //Debug.Log("Setup called");
        
        //Loading.ls = LoadState.LoadNextScene;  //Use this line of code to change the state to load another scene
    }
    // Update is called once per frame
    void Update()
    {
        switch (ls)
        {
            case LoadState.Loading:
                
                break;
            case LoadState.NotLoading:

                break;
            case LoadState.LoadNextScene:
                StartCoroutine(LoadAsyncScene());
                break;
            default:
                break;
        }
    }
    IEnumerator LoadAsyncScene()
    {
        yield return null;
        var i = Random.RandomRange(0,scenes.Count());
        sceneWillLoad = scenes[i];
        AsyncOperation asyncScene = SceneManager.LoadSceneAsync(sceneWillLoad);
        asyncScene.allowSceneActivation = false;
        //float timeCount = 0;
        while (!asyncScene.isDone)
        {
            yield return null;
            //timeCount += Time.deltaTime;
            if (asyncScene.progress >= .9f)
            {
                asyncScene.allowSceneActivation = true;
            }
        }
    }
}
