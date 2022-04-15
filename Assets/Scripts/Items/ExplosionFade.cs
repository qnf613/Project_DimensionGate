using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFade : MonoBehaviour
{

    [SerializeField] private float delay = 1;
    [SerializeField] private AudioClip explosion;
    private void Start()
    {
        StartCoroutine(Explosion());
    }

    private IEnumerator Explosion(){

        AudioSource.PlayClipAtPoint(explosion, transform.position);
        yield return new WaitForSecondsRealtime(delay);
        Destroy(this.gameObject);

    }

}
