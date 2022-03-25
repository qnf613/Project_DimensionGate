using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private float _Speed = 3;
    [SerializeField] private float _RotationSpeed = 1.5f;
    private Transform _Target;
  
   

    private void Awake()
    {
        _Target = FindObjectOfType<Player>().transform;
       

    }

    private void Update()
    {
        var dir = _Target.position - transform.position;

        //transform.up = Vector3.MoveTowards(transform.up, dir, _RotationSpeed* Time.deltaTime);

        //transform.position = Vector3.MoveTowards(transform.position, transform.position + transform.up, _Speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, _Target.position, _Speed * Time.deltaTime);
    }



}
