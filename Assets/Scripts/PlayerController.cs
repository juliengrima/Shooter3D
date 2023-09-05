using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    #region Champs
    [Header("Components")]
    [SerializeField] CharacterController _controller;
    [SerializeField] Animator _animator;
    [SerializeField] Audios _audios;
    [SerializeField] Transform _playerCamera;
    [Header("Action_Components")]
    [SerializeField] InputActionReference _move;
    [SerializeField] InputActionReference _run;
    [SerializeField] InputActionReference _jump;
    [SerializeField] InputActionReference _look;
    [Header("Fieds")]
    [SerializeField] float _speed;
    [SerializeField] float _runSpeed;
    [SerializeField] float _jumpHeight;
    [SerializeField, Range(0, -11)] float _gravity;
    [SerializeField, Range(30, 60)] float _rotationXLimit;
    //Privates Components
    //CharacterController _controller;
    Vector3 playerVelocity;
    //Privates Fields
    bool _isGrounded; //Sphere de collision avec le sol
    bool _isButtonPressed;
    float _horizontal;
    float _vertical;
    
    #endregion
    #region Unity Before Start
    // Start is called before Start() and the first frame update
    private void Reset()
    {
        _speed = 0.5f;
        _runSpeed = 1f;
        _jumpHeight = 1f;
        _gravity = -9.81f;
        _rotationXLimit = 45.0f;
    }
    void Awake()
    {

    }
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    void Start()
    {
        //_controller = gameObject.AddComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        IsGrounded();
        Mouvement();
        look();
    }
    #endregion
    #region Methods
    void IsGrounded()
    {
        _isGrounded = _controller.isGrounded;
        if (_isGrounded && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }
        else
        {
            playerVelocity.y = _gravity;
        }
    }
    void Mouvement()
    {
        Vector2 direction = _move.action.ReadValue<Vector2>();
        //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        Vector3 move = new Vector3(direction.x, 0, direction.y);
        move = _controller.transform.TransformDirection(move);
        _controller.Move(move * Time.deltaTime * _speed);
        //Change vertical position for TPS
        //if (move != Vector3.zero)
        //{
        //    gameObject.transform.forward = move;
        //}
        _controller.Move(playerVelocity * Time.deltaTime);
        
    }
    void jump()
    {
        if (_isButtonPressed)
        {
            if (_jump && _isGrounded)
            {
                playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
            }

            playerVelocity.y += _gravity * Time.deltaTime;
        }
    }
    private void look()
    {
        //throw new NotImplementedException();
        Vector2 look = _look.action.ReadValue<Vector2>();
        _horizontal += look.x;
        _vertical += look.y;
        //On limite rotationX, entre -rotationXLimit et rotationXLimit (-45 et 45)
        _vertical = Mathf.Clamp(_vertical, -_rotationXLimit, _rotationXLimit);
        //Applique la rotation haut/bas sur la caméra
        transform.rotation = Quaternion.Euler(0, _horizontal, 0);
        //mouvement de la souris gauche/droite
        //Applique la rotation gauche/droite sur le Player
        _playerCamera.localRotation = Quaternion.Euler(_vertical ,0 , 0);
        //transform.rotation *= Quaternion.Euler(0, mouse.x * _rotationSpeed, 0);
    }
    void Interaction()
    {

    }
    #endregion
    #region Coroutines
    #endregion
}