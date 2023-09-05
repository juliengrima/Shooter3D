using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class KeyCollider : MonoBehaviour
{
    #region Champs
    [SerializeField] GameObject _PlayerGo;
    [SerializeField] UnityEvent _onPicked;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update


    #endregion
    #region Methods
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //var key = gameObject.GetComponent<>();
            //Inventory weaponsInventory = _PlayerGo.GetComponentInChildren<Inventory>();

            //weaponsInventory.AddWeapon(weapon);
            //_onPicked.Invoke();
        }
    }
    #endregion
    #region Coroutines
    #endregion
}
