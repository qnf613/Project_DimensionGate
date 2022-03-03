
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    [Tooltip("The material that is used when it gets hit")]
    [SerializeField] private Material flashMaterial;

    [Tooltip("Duration of flash.")]
    [SerializeField] private float duration;

  
    private SpriteRenderer spriteRenderer;

    private Material originalMaterial;


    private Coroutine flashRoutine;
    void Start()
    {
        // Get sprite renderer
            spriteRenderer = GetComponent<SpriteRenderer>();

        //get material for sprite renderer
        originalMaterial = spriteRenderer.material;
    }

    public void Flash()
    {

        if (flashRoutine != null)
        {
            StopCoroutine(flashRoutine);
        }


        flashRoutine = StartCoroutine(FlashRoutine());
    }

    private IEnumerator FlashRoutine()
    {
        // Swap material to flash
        spriteRenderer.material = flashMaterial;

        // Pausing
        yield return new WaitForSeconds(duration);

        // Swap back to original
        spriteRenderer.material = originalMaterial;
        
        flashRoutine = null;
    }


}
