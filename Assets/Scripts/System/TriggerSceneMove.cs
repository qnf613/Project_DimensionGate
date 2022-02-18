using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerSceneMove : ManageScene
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //If trigger collides with player, 
        if (collision.gameObject.GetComponent<Player>() == null) { }
        else
        {
            //Load the intended scene
            StartCoroutine(LoadScene());
            Debug.Log("Entered new scene trigger");
        } 
    }
}
