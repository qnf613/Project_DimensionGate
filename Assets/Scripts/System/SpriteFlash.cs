
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteFlash : MonoBehaviour
{
    [Tooltip("The material that is used when it gets hit")]
    [SerializeField] private Material flashMaterial;

    [Tooltip("Duration of flash.")]
    [SerializeField] private float duration;

    [SerializeField] private Color originalColor;
  
    private SpriteRenderer spriteRenderer;

    private Material originalMaterial;


    private Coroutine flashRoutine;
    void Start()
    {
        originalColor = this.gameObject.GetComponent<SpriteRenderer>().color;
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
        spriteRenderer.color = Color.red;
        // Pausing
        yield return new WaitForSeconds(duration);

        // Swap back to original
        spriteRenderer.material = originalMaterial;
        spriteRenderer.color = originalColor;

        flashRoutine = null;
    }


}
