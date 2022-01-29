using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField] private float inputX;
    [SerializeField] private float inputY;
    [SerializeField] private float speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        inputX = Input.GetAxis("Horizontal");
        inputY = Input.GetAxis("Vertical");
    }

    void FixedUpdate()
    {
        Vector2 movement = new Vector2(speed * inputX, speed * inputY);
        movement *= Time.deltaTime;
        transform.Translate(movement);
    }
}
