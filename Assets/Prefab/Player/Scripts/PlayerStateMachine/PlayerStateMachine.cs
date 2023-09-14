using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEditor.Rendering.InspectorCurveEditor;

public class PlayerStateMachine : MonoBehaviour
{
    #region Champs
    [SerializeField] InputActionReference _move;
    [SerializeField] InputActionReference _jump;
    [SerializeField] InputActionReference _crunch;

    Animator _animator;
    enum PlayerState
    {
        IDLE,
        WALK,
        RUN,
        JUMP,
        CRUNCH,
        FALL,
        DEATH
    }

    PlayerState _currentState = PlayerState.IDLE;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    void Awake()
    {
        _animator = GetComponent<Animator>();
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
    void FixedUpdate()
    {

    }
    void LateUpdate()
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
            case PlayerState.IDLE:
                _animator.SetBool("IDLE", true);
                break;
            case PlayerState.WALK:
                _animator.GetFloat(1);
                break;
            case PlayerState.RUN:
                _animator.GetBool(6);
                break;
            case PlayerState.JUMP:
                _animator.SetTrigger("JUMP");
                break;
            case PlayerState.CRUNCH:
                _animator.SetBool("CRUNCH", true);
                break;
            case PlayerState.FALL:
                _animator.SetBool("FALL", true);
                break;
            case PlayerState.DEATH:
                _animator.SetBool("DEATH", true);
                break;
            default:
                break;
        }
    }
    void OnStateUpdate()
    {
        switch (_currentState)
        {
            case PlayerState.IDLE:
                _animator.SetBool("IDLE", false);
                break;
            case PlayerState.WALK:
                _animator.SetBool("WALK", false);
                break;
            case PlayerState.RUN:
                _animator.SetBool("RUN", false);
                break;
            case PlayerState.JUMP:

                break;
            case PlayerState.CRUNCH:
                _animator.SetBool("CRUNCH", false);
                break;
            case PlayerState.FALL:
                _animator.SetBool("FALL", false);
                break;
            case PlayerState.DEATH:

                break;
            default:
                break;
        }
    }
    void OnStateExit()
    {
        switch (_currentState)
        {
            case PlayerState.IDLE:

                break;
            case PlayerState.WALK:

                break;
            case PlayerState.RUN:

                break;
            case PlayerState.JUMP:

                break;
            case PlayerState.CRUNCH:

                break;
            case PlayerState.FALL:

                break;
            case PlayerState.DEATH:

                break;
            default:
                break;
        }
    }
    void TransitionToState(PlayerState nextState)
    {
        OnStateExit();
        _currentState = nextState;
        OnStateEnter();
    }
    #endregion
}
