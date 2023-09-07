using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    #region Champs
    [Header("Lists")]
    [SerializeField] List<GameObject> _inventory = new List<GameObject>(); // Liste de GameObject Keys
    [SerializeField] List<GameObject> _weapons = new List<GameObject>(); // Liste de GameObject Weapons
    [SerializeField] List<GameObject> _tools = new List<GameObject>(); // Liste de GameObject Tools

    public List<GameObject> itemInventory { get => _inventory; set => _inventory = value; }
    public List<GameObject> Weapons { get => _weapons; set => _weapons = value; }
    #endregion
    #region Unity LifeCycle
    #endregion
    #region Methods ITEMS
    public void AddItem(GameObject item)
    {
        var count = itemInventory.Count;
        if (count > 3)
        {
            Debug.Log($"Votre inventaire est plein !");
            string error = $"Vous avez atteinds le nombre maximal de clés - nb keys{count}";
        }
        else
        {
            itemInventory.Add(item);
        }
        
    }
    public void RemoveItem(GameObject item)
    {
        itemInventory.Remove(item);
    }
    public bool HasItem(GameObject item)
    {
        return itemInventory.Contains(item);
    }
    #endregion
    #region Methods Weapons
    public void AddWeapons(GameObject weapon)
    {
        throw new NotImplementedException();
    }
    public void RemoveWeapons(GameObject weapon)
    {
        throw new NotImplementedException();
    }
    public bool HasWeapons(GameObject weapon)
    {
        throw new NotImplementedException();

    }
    #endregion
    #region Methods Tools
    public void AddTools(GameObject Tool)
    {
        throw new NotImplementedException();
    }
    public void RemoveTools(GameObject Tool)
    {
        throw new NotImplementedException();
    }
    public bool HasTools(GameObject Tool)
    {
        throw new NotImplementedException();

    }
    #endregion
    #region Coroutines
    #endregion
}