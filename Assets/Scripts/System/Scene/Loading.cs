using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using TMPro;

public class Loading : MonoBehaviour
{
    public string sceneWillLoad;
    public TextMeshProUGUI announceText;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadAsyncScene());
    }
    public void SetUp()
    {
       
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
        while (!asyncScene.isDone)
        {
            if (asyncScene.progress >= .9f)
            {
                yield return new WaitForSecondsRealtime(3f);

                //announceText.text = "Loading done! Press Space to progress to the next stage";

                //if (Input.GetKeyDown(KeyCode.Space))
                //{

                //}
                asyncScene.allowSceneActivation = true;

            }
            yield return null;
        }
    }
}
