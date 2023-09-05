using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Inventory : MonoBehaviour
{
    #region Champs
    [Header("Lists")]
    //[SerializeField] List<Weapon> weapons = new List<Weapon>(); // Liste d'armes
    [SerializeField] List<Key> keys = new List<Key>(); // Liste de clés

    //public List<Weapon> Weapons { get => weapons; set => weapons = value; }
    public List<Key> Keys { get => keys; set => keys = value; }

    //private int selectedWeaponIndex = 0; // Index de l'arme actuellement sélectionnée
    //public int SelectedWeaponIndex
    //{
    //    get => selectedWeaponIndex;
    //    set => selectedWeaponIndex = Mathf.Clamp(value, 0, Weapons.Count - 1);
    //}
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    private void Update()
    {

    }
    #endregion
    #region Methods
    //public void AddWeapon(Weapon weapon)
    //{
    //    int weaponIndex = weapon.GetWeaponIndex();
    //    // Vérifier si l'arme avec le même index existe déjà dans l'inventaire
    //    if (!HasWeaponWithIndex(weaponIndex))
    //    {
    //        Weapons.Add(weapon);
    //    }
    //    else
    //    {
    //        weapon.ReloadAmmo(weapon.MaxAmmo);
    //    }
    //}
    ////public void RemoveWeapon(Weapon weapon)
    ////{
    ////    Weapons.Remove(weapon);
    ////}
    //public bool HasWeapon(Weapon weapon)
    //{
    //    return Weapons.Contains(weapon);
    //}
    //public bool HasWeaponWithIndex(int weaponIndex)
    //{
    //    foreach (var weapon in Weapons)
    //    {
    //        if (weapon.GetWeaponIndex() == weaponIndex)
    //        {
    //            return true;
    //        }
    //    }
    //    return false;
    //}
    public void AddKey(Key key)
    {
        Keys.Add(key);
    }
    public void RemoveKey(Key key)
    {
        Keys.Remove(key);
    }
    public bool HasKey(Key key)
    {
        return Keys.Contains(key);
    }
    #endregion
    #region Coroutines
    #endregion
}