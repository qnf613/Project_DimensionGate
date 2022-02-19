using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamagePopUpMovement : MonoBehaviour
{

    [SerializeField] private float speed = .3f;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, .5f);
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += Vector3.up * speed * Time.deltaTime;
    }
}
