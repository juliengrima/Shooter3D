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
    [SerializeField] int _damage;
    //[SerializeField] List<string> _tags;

    bool _use;
    public bool Use { get => _use; }
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
        ////Dessine la ligne du Raycast
        //Debug.DrawRay(transform.position, Vector3.forward * _rayDistance, Color.red);
        //RaycastHit hit;
        //Ray ray = new Ray(transform.position, Vector3.forward);

        //int layer_mask = LayerMask.GetMask("Default");
        //if (Physics.Raycast(ray, out hit, Mathf.Infinity, layer_mask, QueryTriggerInteraction.Ignore))
        //{
        //    print(hit.transform.name + " traverse le rayon.");
        //    print("La distance est de " + hit.distance);
        //    _weapon.transform.position = hit.point;
        //    var hited = hit.collider.name;
        //    // Affichage du nom de l'item par Canvas

        //    if (_fire.action.WasPerformedThisFrame())
        //    {
        //        bool action = _fire.action.WasPerformedThisFrame();
        //        if (hit.collider.TryGetComponent(out IInteractable usable))
        //        {
        //            usable.Use(action);
        //        }
        //    }
        //}

        //RAYCAST CODE POUR TOUT
        //Calcule le point central de l'écran
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        // Demande à la camera de donner un rayon qui part dans la direction
        Ray cameraRay = _camera.ScreenPointToRay(screenCenter);
        Debug.DrawRay(cameraRay.origin, cameraRay.direction, Color.red);

        if (_fire.action.WasPerformedThisFrame())
        {
            if (Physics.Raycast(cameraRay, out RaycastHit hit, _rayDistance))
            {
                //Debug.Log($"Touché {hit.collider.name}");
                var hited = hit.collider.name;
                // Affichage du nom de l'item par Canvas
                bool action = _fire.action.WasPerformedThisFrame();
                if (hit.collider.TryGetComponent(out IHealth usable))
                {
                    usable.TakeDamage(_damage);
                }
            }
        }
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
}

