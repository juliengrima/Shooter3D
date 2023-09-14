using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class StateMachineEx : MonoBehaviour, IInteractable
{
    #region Champs
    [SerializeField] InputActionReference _action;

    Renderer _renderer;
    enum CubeState
    {
        WHITE,
        GREEN,
        RED,
        BLUE
    }

    CubeState _currentState = CubeState.WHITE;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    public void Update()
    {
        OnStateUpdate();
    }
    #endregion
    #region Methods
    void FixedUpdate ()
    {
        
    }
    void LateUpdate ()
    {
        
    }
    #endregion
    #region Coroutines
    #endregion
    #region States
    public void Use(bool action)
    {
        OnStateUpdate();
    }
    void OnStateEnter()
    {
        switch (_currentState)
        {
            case CubeState.WHITE:
                _renderer.material.color = Color.green;
                break;
            case CubeState.GREEN:
                _renderer.material.color = Color.red;   
                break;
            case CubeState.RED:
                _renderer.material.color = Color.blue; 
                break;
            case CubeState.BLUE:
                _renderer.material.color = Color.white;
                break;
            default:
                break;
        }
    }
    void OnStateUpdate()
    {
        switch (_currentState)
        {
            case CubeState.WHITE:
                if (_action.action.WasPerformedThisFrame())
                {
                    TransitionToState(CubeState.GREEN);
                }
                break;
            case CubeState.GREEN:
                if (_action.action.WasPerformedThisFrame())
                {
                    TransitionToState(CubeState.RED);
                }
                break;
            case CubeState.RED:
                if (_action.action.WasPerformedThisFrame())
                {
                    TransitionToState(CubeState.BLUE);
                }
                break;
            case CubeState.BLUE:
                if (_action.action.WasPerformedThisFrame())
                {
                    TransitionToState(CubeState.WHITE);
                }
                break;
            default:
                break;
        }
    }
    void OnStateExit()
    {
        switch (_currentState)
        {
            case CubeState.WHITE:
                break;
            case CubeState.GREEN:
                break;
            case CubeState.RED:
                break;
            case CubeState.BLUE:
                break;
            default:
                break;
        }
    }
    void TransitionToState(CubeState nextState)
    {
        OnStateExit();
        _currentState = nextState;
        OnStateEnter();
    }
    #endregion
}
