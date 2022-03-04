using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlashDeath : MonoBehaviour
{

    public float fadeSpeed;

    //private SpriteRenderer spriteRenderer;

    private Coroutine fadeRoutine;

    void Start()
    {
        //spriteRenderer = GetComponent<SpriteRenderer>();
        
    }


    public void Fade()
    {
        if (fadeRoutine != null)
        {
            StopCoroutine(fadeRoutine);
        }
        fadeRoutine = StartCoroutine(FadeRoutine());
        
    }
    private IEnumerator FadeRoutine()
    {
        while (this.GetComponent<Renderer>().material.color.a > 0)
        {
            Color objectColor = this.GetComponent<Renderer>().material.color;
            float fadeAmount = objectColor.a - (fadeSpeed * Time.deltaTime);

            objectColor = new Color(objectColor.r, objectColor.g, objectColor.b, fadeAmount);
            this.GetComponent<Renderer>().material.color = objectColor;
            yield return null;
        }
        

        

        fadeRoutine = null;
    }
}
