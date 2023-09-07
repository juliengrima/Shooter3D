using System;
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
    [Header("Scriptable_Components")]
    [SerializeField] Inventory _inventory; // Référence au script Inventory
    [SerializeField] Transform _weaponSpawner;
    [Header("Action_Components")]
    [SerializeField] InputActionReference _move;
    [SerializeField] InputActionReference _run;
    [SerializeField] InputActionReference _jump;
    [SerializeField] InputActionReference _look;
    [SerializeField] InputActionReference _mouseWheel;
    [SerializeField] InputActionReference _keyboard;
    //[SerializeField] InputActionReference _fire;
    [Header("Fieds")]
    [SerializeField] float _speed;
    [SerializeField] float _runSpeed;
    [SerializeField] float _jumpHeight;
    [SerializeField, Range(0, -11)] float _gravity;
    [SerializeField, Range(30, 60)] float _rotationXLimit;
    //Privates Components
    Vector3 playerVelocity;
    //Privates Fields
    bool _isGrounded; //Sphere de collision avec le sol
    bool _isButtonPressed;
    float _horizontal;
    float _vertical;
    private int selectedWeaponIndex = 0; // Index de l'arme sélectionnée
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
        Cursor.lockState = CursorLockMode.Locked;
    }
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    // Update is called once per frame
    void Update()
    {
        IsGrounded();
        Mouvement();
        jump();
        look();
        GetNextScrollWeapon();
    }
    #endregion
    #region Methods
    void IsGrounded()
    {
        _isGrounded = _controller.isGrounded;
        if (_isGrounded)
        {
            playerVelocity.y = 0f;
        }
        // Update gravity
        playerVelocity.y += _gravity * Time.deltaTime;
    }
    void Mouvement()
    {
        Vector2 direction = _move.action.ReadValue<Vector2>();
        Vector3 move = new Vector3(direction.x, 0, direction.y);
        move = _controller.transform.TransformDirection(move);
        _controller.Move(move * Time.deltaTime * _speed);
        // If Running
        _isButtonPressed = _run.action.IsPressed();
        if (_isButtonPressed)
        {
            _controller.Move(move * Time.deltaTime * _runSpeed);
        }
        _controller.Move(playerVelocity * Time.deltaTime);
    }
    void jump()
    {
        _isButtonPressed = _jump.action.IsPressed();
        if (_isButtonPressed && _isGrounded)
        {
            playerVelocity.y += Mathf.Sqrt(_jumpHeight * -3.0f * _gravity);
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
            _playerCamera.localRotation = Quaternion.Euler(_vertical, 0, 0);
    }
    public int GetNextScrollWeapon()
    {

        //throw new NotImplementedException();
        //bool selection = _mouseWheel.action.IsPressed();
        Vector2 selection = _mouseWheel.action.ReadValue<Vector2>();
        // Gérer le changement d'arme en fonction du défilement de la molette
        if (_inventory.Weapons.Count == 0) return -1;
        if (selection.y > 0)
        {
            selectedWeaponIndex++;
            if (selectedWeaponIndex >= _inventory.Weapons.Count)
            {
                selectedWeaponIndex = 0;
                //_player.transform.SetParent(transform);  INSTANCIATE GAMEOBJET VIDE
                var t = Instantiate(_inventory.Weapons[selectedWeaponIndex], _weaponSpawner);
                var w = t.GetComponent<Weapon>();
                w.Position();
                w.gameObject.SetActive(true);
            }
            else
            {
                return _inventory.SelectedWeaponIndex;
            }
        }
        else if (selection.y < 0)
        {
            selectedWeaponIndex--;
            if (selectedWeaponIndex < 0)
            {
                selectedWeaponIndex = _inventory.Weapons.Count - 1;
                //_player.transform.SetParent(transform);  INSTANCIATE GAMEOBJET VIDE
                var t = Instantiate(_inventory.Weapons[selectedWeaponIndex], _weaponSpawner);
                var w = t.GetComponent<Weapon>();
                w.Position();
                w.gameObject.SetActive(true);

            }
            else
            {

                return _inventory.SelectedWeaponIndex;
            }
        }
        // Mettre à jour l'arme actuellement sélectionnée dans l'inventaire
        _inventory.SelectedWeaponIndex = selectedWeaponIndex;

        return _inventory.SelectedWeaponIndex;
    }
    private int GetNextKeyWeapon()
    {
        //throw new NotImplementedException();
        var selection = _keyboard.action.ReadValue<Vector2>();
        if (_inventory.Weapons.Count == 0) return -1;
        if (selection.y > 0)
        {
            selectedWeaponIndex++;
            if (selectedWeaponIndex >= _inventory.Weapons.Count)
            {
                selectedWeaponIndex = 0;
                //_player.transform.SetParent(transform);  INSTANCIATE GAMEOBJET VIDE
                var t = Instantiate(_inventory.Weapons[selectedWeaponIndex], _weaponSpawner);
                var w = t.GetComponent<Weapon>();
                w.Position();
                w.gameObject.SetActive(true);
            }
        }
        else if (selection.y < 0)
        {
            selectedWeaponIndex--;
            if (selectedWeaponIndex < 0)
            {
                selectedWeaponIndex = _inventory.Weapons.Count - 1;
                //_player.transform.SetParent(transform);  INSTANCIATE GAMEOBJET VIDE
                var t = Instantiate(_inventory.Weapons[selectedWeaponIndex], _weaponSpawner);
                var w = t.GetComponent<Weapon>();
                w.Position();
                w.gameObject.SetActive(true);
            }
        }
        // Mettre à jour l'arme actuellement sélectionnée dans l'inventaire
        _inventory.SelectedWeaponIndex = selectedWeaponIndex;

        return _inventory.SelectedWeaponIndex;
    }
    #endregion
    #region Coroutines
    #endregion
}