using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosionFade : MonoBehaviour
{

    [SerializeField] private float delay;
    private void Start()
    {
        //todo: change to make opacity go to zero and then destroy to make it look smoother
        Destroy(this.gameObject, delay);
        Debug.Log("destroying explosion");
    }
}
