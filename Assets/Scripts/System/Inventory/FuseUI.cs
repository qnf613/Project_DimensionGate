using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuseUI : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (this.gameObject.activeInHierarchy && Input.GetKeyDown(KeyCode.Tab))
        {
            this.gameObject.SetActive(false);
        }
    }
}
