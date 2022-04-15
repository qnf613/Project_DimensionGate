using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ActivatePortal : MonoBehaviour
{
    [SerializeField] private Collider2D cd;
    [SerializeField] private GameObject keyButtonIcon;
    [SerializeField] private string sceneToLoad;
    [SerializeField] private bool loadOnce;
    // Start is called before the first frame update
    void Start()
    {
        cd = GetComponent<Collider2D>();
        if (GameObject.Find("ClearManager") != null)
        {
            sceneToLoad = GameObject.Find("ClearManager").GetComponent<ClearCondition>().nextLoadingScreen;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (loadOnce)
        {
            SceneManager.LoadScene(sceneToLoad);
            loadOnce = false;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            keyButtonIcon.SetActive(true);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            Loading.ls = LoadState.Loading;
            Debug.Log("Space Pressing");
            loadOnce = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            keyButtonIcon.SetActive(false);
        }
    }


}
