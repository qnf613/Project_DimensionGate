using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutoDestroyAfterXseconds : MonoBehaviour
{
    public float timerUntillDestruction = 15;
    // Start is called before the first frame update
    void Start()
    {
       Destroy(this.gameObject, timerUntillDestruction);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
