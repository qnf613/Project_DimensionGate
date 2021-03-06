using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{

    [SerializeField] private string sceneToLoad;
    public GameObject creditUI;
    private bool creditUIOpen;
    public GameObject animations;
    // Start is called before the first frame update
    void Start()
    {
        creditUIOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(creditUIOpen)
        {
            if(Input.GetKeyDown(KeyCode.Escape))
            {
                creditUI.SetActive(false);
                animations.SetActive(true);
                creditUIOpen = false;
            }
        }
    }

    public void loadScene()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }
        StartCoroutine(LoadAsyncScene());
    }

    public void popCreditUI()
    {
        creditUI.SetActive(true);
        creditUIOpen = true;
        animations.SetActive(false);
        
    }

    public void Quit()
    {
        Application.Quit();
    }

    IEnumerator LoadAsyncScene()
    {
        yield return null;
        AsyncOperation asyncScene = SceneManager.LoadSceneAsync(sceneToLoad);
        asyncScene.allowSceneActivation = false;
        while (!asyncScene.isDone)
        {
            if (asyncScene.progress >= .9f)
            {
                asyncScene.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
