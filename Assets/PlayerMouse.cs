using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMouse : MonoBehaviour
{
    #region Champs
    [Header("Action_Component")]
    [SerializeField] InputActionReference _mouse;
    [Header("Player_Component")]
    [SerializeField] Transform _playerCamera;

    public static bool _mousePresent;
    float _scale;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    // Update is called once per frame
    private void Awake()
    {
        var player = _playerCamera.transform;
    }
    void Update()
    {
        
    }
    #endregion
    #region Methods
    public void MouseLook()
    {
        if (_mousePresent)
        {
            Vector2 pos = _playerCamera.position;
            pos.y += Input.mouseScrollDelta.y * _scale;
            _playerCamera.position = pos;
        }
    }
    #endregion
    #region Coroutines
    #endregion
}
