using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Screenshots : MonoBehaviour
{
    // Start is called before the first frame update

    void Update()
    {
        if(Input.GetKeyDown("space"))
        {
            ScreenCapture.CaptureScreenshot("Screenshot.png");
        }
        
    }
}
