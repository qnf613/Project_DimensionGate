using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneButton : MonoBehaviour
{
    [SerializeField] protected string sceneToLoad;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void loadScene()
    {
        if (Time.timeScale != 1f)
        {
            Time.timeScale = 1f;
        }
        SceneManager.LoadScene(sceneToLoad);
    }
}
