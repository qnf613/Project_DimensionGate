using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;
public class FuseButton : MonoBehaviour/*, IPointerDownHandler*/
{
    public GameObject fuseUI;
    public Image[] sprites;
    // Start is called before the first frame update
    void Start()
    {
        if (fuseUI == null)
        {
            fuseUI = GameObject.Find("FuseUI");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Fuse()
    {
        Debug.Log("This button (" + this.gameObject.name + ") has been clicked");
        CloseFuseUI();
    }

    public void CloseFuseUI()
    {
        fuseUI.SetActive(false);
    }
}
