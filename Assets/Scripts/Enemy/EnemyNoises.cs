using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyNoises : MonoBehaviour
{
    [SerializeField] private AudioClip ambientSFX;
    [SerializeField] private float volume = 0.50f;
    private float min = 5f;
    private float max = 10f;
    private void Awake()
    {
        if (ambientSFX != null)
        {
            Invoke("AmbientNoises", 0.2f);
        }
    }

    void AmbientNoises()
    {
        float randomtime = Random.Range(min, max);
        AudioSource.PlayClipAtPoint(ambientSFX, transform.position, volume);
        Invoke("AmbientNoises", randomtime);
    }
}
