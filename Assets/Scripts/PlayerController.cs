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
    [Header("Action_Compoenents")]
    [SerializeField] InputActionReference _move;
    [SerializeField] InputActionReference _run;
    [SerializeField] InputActionReference _jump;
    [SerializeField] InputActionReference _use;
    [Header("Fieds")]
    [SerializeField] float _speed;
    [SerializeField] float _runSpeed;
    [SerializeField] float _jumpHeight;
    [SerializeField] float _gravity;


    //Privates Components
    //CharacterController _controller;
    Vector3 playerVelocity;
    Coroutine _coroutine;
    //Privates Fields
    bool _isGrounded; //Sphere de collision avec le sol
    bool _isButtonPressed;
    #endregion
    #region Unity Before Start
    // Start is called before Start() and the first frame update
    private void Reset()
    {
        _speed = 0.5f;
        _runSpeed = 1f;
        _jumpHeight = 1f;
        _gravity = -9.81f;
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
    }
    void Mouvement()
    {
        Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        _controller.Move(move * Time.deltaTime * _speed);

        //Change vertical position
        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

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
        // Changes the height position of the player..   
    }
    void FixedUpdate()
    {

    }
    void LateUpdate()
    {

    }
    #endregion
    #region Coroutines
    #endregion
}