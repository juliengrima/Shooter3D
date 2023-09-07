using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Key : MonoBehaviour, IInteractable
{
    #region Champs
    [Header("Components")]
    [SerializeField] Inventory _inventory;
    [Header("Events")]
    [SerializeField] UnityEvent _onUsed;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    // Update is called once per frame
    #endregion
    #region Methods
    public void Use(bool action)
    {
        var item = gameObject;
        //Inventory itemInventory = gameObject.GetComponent<Inventory>();
        _inventory.AddItem(item);
        _onUsed.Invoke();
    }
    #endregion
    #region Coroutines
    #endregion
}