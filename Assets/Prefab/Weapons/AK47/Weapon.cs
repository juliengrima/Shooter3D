using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour, IInteractable
{
    #region Champs
    [Header("Components")]
    [SerializeField] Inventory _inventory;
    [Header("Audio_Components")]
    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip _reload;
    [SerializeField] AudioClip _isFire;
    [Header("Fields")]
    [SerializeField] private int _weaponIndex; // Index de l'arme
    [SerializeField] private int _maxAmmo; // Nombre maximum de munitions
    [SerializeField] float _fireRate;
    [SerializeField] int _damage;
    [Header("Cursors")]
    //[SerializeField] CursorPosition _aimCursor; // AIM CURSOR POINT
    [Header("Events")]
    [SerializeField] UnityEvent _onUsed;
    [SerializeField] UnityEvent _onFire;
    [Header("Weapon_Position")]
    [SerializeField] Vector3 _position = Vector3.zero;
    [SerializeField] Vector3 _rotation;
    [SerializeField] Vector3 _scale = Vector3.one;

    private int _currentAmmo; // Munitions actuelles
    public int WeaponIndex { get => _weaponIndex; }
    public int MaxAmmo { get => _maxAmmo; }
    public float FireRate { get => _fireRate; }
    public int Damage { get => _damage; }
    public int CurrentAmmo { get => _currentAmmo; set => _currentAmmo = value; }
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    // Update is called once per frame
    #endregion
    #region Unity LifeCycle
    private void Reset()
    {
        _maxAmmo = 100;
        _damage = 10;
    }
    // Start is called before the first frame update
    private void Start()
    {
        CurrentAmmo = _maxAmmo; // Start wth Maximum Ammo
    }
    #endregion
    #region Methods
    public void Use(bool action)
    {
        _source.PlayOneShot(_reload);
        _inventory.AddWeapons(this);
        _onUsed.Invoke();
    }

    public void Position()
    {
        transform.localPosition = _position;
        transform.localRotation = Quaternion.Euler(_rotation);
        transform.localScale = _scale;
    }
    public int GetWeaponIndex()
    {
        return WeaponIndex;
    }
    public void UseAmmo()
    {
        if (CurrentAmmo > 0)
        {
            CurrentAmmo--;
            Debug.Log($"Reste : {CurrentAmmo} ammo");
        }
    }
    public void ReloadAmmo(int _maxAmmo)
    {
        _source.PlayOneShot(_reload);
        CurrentAmmo = _maxAmmo; // Rechargez les munitions
    }
    #endregion
    #region Coroutines
    #endregion
    #region Coroutines
    public void Shoot()
    {  
        _onFire.Invoke();
        _source.PlayOneShot(_isFire);
        UseAmmo(); // Déduire une munition     
    }
    #endregion
}
