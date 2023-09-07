using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;

public class Interaction : MonoBehaviour
{
    #region Champs
    [Header("Components")]
    [SerializeField] Camera _camera;
    [SerializeField] InputActionReference _action;
    [Header("Fields")]
    [SerializeField] float _rayDistance;

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
        //RAYCAST CODE POUR TOUT
        //Calcule le point central de l'écran
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        // Demande à la camera de donner un rayon qui part dans la direction
        Ray cameraRay = _camera.ScreenPointToRay(screenCenter);
        Debug.DrawRay(cameraRay.origin, cameraRay.direction, Color.red);

        if (Physics.Raycast(cameraRay, out RaycastHit hit,_rayDistance))
        {
            Debug.Log($"Touché {hit.collider.name}");
            var hited = hit.collider.name;
            // Affichage du nom de l'item par Canvas
            if (_action.action.WasPerformedThisFrame())
            {
                bool action = _action.action.WasPerformedThisFrame();
                if (hit.collider.TryGetComponent(out IInteractable usable))
                {
                    usable.Use(action);
                }
                
            }
        }
    }
    #endregion
    #region Methods
    #endregion
    #region Coroutines
    #endregion
}
