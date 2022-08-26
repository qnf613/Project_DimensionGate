using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CutScene : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    [SerializeField] private bool loadOnce = false;
    [SerializeField] private bool playSFX = false;
    public AudioClip sfx;
    public float lengthOfSceneInSec;
    public float playTimeCounter = 0;
    public float notAllowSkipUntilThis;
    
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        playTimeCounter += Time.deltaTime;
        if (playTimeCounter >= .5f)
        {
            if (!playSFX)
            {
                playSFX = true;
                AudioSource.PlayClipAtPoint(sfx, transform.position, 1f);
            }
        }
            
        if (playTimeCounter >= notAllowSkipUntilThis)
        {
            if (playTimeCounter >= lengthOfSceneInSec || Input.anyKeyDown)
            {
                StartCoroutine(LoadAsyncScene());
            }
        }
    }
    IEnumerator LoadAsyncScene()
    {
        if (!loadOnce)
        {
            loadOnce = true;
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
}
