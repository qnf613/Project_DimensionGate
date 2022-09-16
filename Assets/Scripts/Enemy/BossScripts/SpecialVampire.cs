using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialVampire : MonoBehaviour
{
    [SerializeField] private int rotationspeed;


    void Update()
    {
        transform.Rotate(new Vector3(0, 0, rotationspeed) * Time.deltaTime);
    }
}
