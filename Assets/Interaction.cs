using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interaction : MonoBehaviour
{
    #region Champs
    [Header("Components")]
    [SerializeField] Camera _camera;
    [Header("Fields")]
    [SerializeField] float _rayDistance;
    [SerializeField] List<string> _tags;

    bool _use;
    public bool Use { get => _use; }
    public List<string> Tags { get => _tags; set => _tags = value; }
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    private void Reset()
    {
        _rayDistance = 5f;
        _use = false;
    }
    void Awake()
    {
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Calcule le point central de l'écran
        Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
        // Demande à la camera de donner un rayon qui part dans la direction
        Ray cameraRay = _camera.ScreenPointToRay(screenCenter);
        Debug.DrawRay(cameraRay.origin, cameraRay.direction, Color.magenta);

        if (Physics.Raycast(cameraRay, out RaycastHit hit,_rayDistance))
        {
            Debug.Log($"Touché {hit.collider.name}");
            var hited = hit.collider.tag;
            foreach (string tag in Tags)
            {
                if (tag == "key")
                {
                    Inventory Inventory = gameObject.GetComponent<Inventory>();
                }
            }
            
            _use = true;
        }
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
}
