using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    public float _Speed;
    [SerializeField] Camera _Camera;

    PlayerInput _Input;

    Vector2 _Movement;
    Vector2 _MousePos;
    Rigidbody2D _Rigidbody;
    public GameObject graphicGO;
    [SerializeField] private PlayerStats _Stats;


    private void Awake()
    {
        _Input = new PlayerInput();
        _Rigidbody = GetComponent<Rigidbody2D>();
        _Stats = GetComponent<PlayerStats>();
    }
    private void Start()
    {
        _Speed = _Stats.originalSpeed;
    }
    private void OnEnable()
    {
        _Input.Enable();

        _Input.Gameplay.Movement.performed += OnMovement;
        _Input.Gameplay.Movement.canceled += OnMovement;


        _Input.Gameplay.MousePos.performed += OnMousePos;
    }
    private void OnDisable()
    {
        _Input.Disable();
    }

    private void OnMousePos(InputAction.CallbackContext context)
    {
        _MousePos = _Camera.ScreenToWorldPoint(context.ReadValue<Vector2>());
    }

    private void OnMovement(InputAction.CallbackContext context)
    {
        _Movement = context.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        _Rigidbody.velocity = _Movement * _Speed;

        Vector2 facingDirection = _MousePos - _Rigidbody.position;
        float angle = Mathf.Atan2(facingDirection.y, facingDirection.x) * Mathf.Rad2Deg;
        _Rigidbody.MoveRotation(angle);


        if (_Rigidbody.velocity.x >= 0.01f)
        {
            graphicGO.transform.localScale = new Vector3(1f, 1f, 1f);
        }
        else if (_Rigidbody.velocity.x <= -0.01f)
        {
            graphicGO.transform.localScale = new Vector3(-1f, 1f, 1f);
        }

    }

    private void Update()
    {

    }
}
