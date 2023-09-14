using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class FireController : MonoBehaviour
{
    #region Champs
    [Header("Camera_Components")]
    [SerializeField] Camera _camera;
    [Header("Components")]
    [SerializeField] GameObject _weapon;
    [SerializeField] InputActionReference _fire;
    //[Header("Events")]
    //[SerializeField] UnityEvent _onPicked;
    [Header("Fields")]
    [SerializeField] float _rayDistance;
    //Privates Fields
    bool _use;
    public bool Use { get => _use; }

    Coroutine _fireCoroutine;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    private void Reset()
    {
        _rayDistance = 5f;
        _use = false;
    }
    // Update is called once per frame
    void Update()
    {

        if (_fire.action.WasPressedThisFrame())
        {
            _fireCoroutine = StartCoroutine(FireRoutine());
          
        }
        else if(_fire.action.WasReleasedThisFrame())
        {
            StopCoroutine(_fireCoroutine);
        }
    }
    #endregion
    #region Methods
    #endregion
    #region Coroutines
    IEnumerator FireRoutine()
    {
        while (_fire.action.IsPressed())
        {
            //Calcule le point central de l'écran
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            // Demande à la camera de donner un rayon qui part dans la direction
            Ray cameraRay = _camera.ScreenPointToRay(screenCenter);
            Debug.DrawRay(cameraRay.origin, cameraRay.direction, Color.red);

            var shoot = gameObject.GetComponent<Weapon>();
            if (shoot.CurrentAmmo > 0)
            {
                shoot.Shoot();
                if (Physics.Raycast(cameraRay, out RaycastHit hit, _rayDistance))
                {
                    //Debug.Log($"Touché {hit.collider.name}");
                    var hited = hit.collider.name;
                    // Affichage du nom de l'item par Canvas
                    //bool action = _fire.action.WasPerformedThisFrame();
                    if (hit.collider.TryGetComponent(out IHealth usable))
                    {
                        usable.TakeDamage(shoot.Damage);   
                    }
                }
                yield return new WaitForSeconds(shoot.FireRate);
            }
            else
            {
                //One day will come effects
            }
            yield return null;
        }
    }
    #endregion
}

