using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] float _Speed = 1;
    [SerializeField] Camera _Camera;

    PlayerInput _Input;

    Vector2 _Movement;
    Vector2 _MousePos;
    Rigidbody2D _Rigidbody;
    //Temp animation changer
    public GameObject graphicGO;
    public Animator _Animator;
    public bool characterChanged;
    public RuntimeAnimatorController chara1;
    public RuntimeAnimatorController chara2;


    private void Awake()
    {
        _Input = new PlayerInput();
        _Rigidbody = GetComponent<Rigidbody2D>();
        _Animator = graphicGO.GetComponent<Animator>(); //Temp animation changer
        characterChanged = false;
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
        //Temp animation changer
        if (Input.GetKeyUp(KeyCode.K))
        {
            if (!characterChanged)
            {
                _Animator.runtimeAnimatorController = chara2 as RuntimeAnimatorController;
                characterChanged = true;
            }
            else if (characterChanged)
            {
                _Animator.runtimeAnimatorController = chara1 as RuntimeAnimatorController;
                characterChanged = false;
            }
        }
    }
}
