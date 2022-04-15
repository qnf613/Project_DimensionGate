using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Loading : MonoBehaviour
{
    public string sceneWillLoad;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncScene());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    IEnumerator LoadAsyncScene()
    {
        yield return null;
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
