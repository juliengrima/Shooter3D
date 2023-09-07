using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

public class Weapon : MonoBehaviour, IInteractable
{
    #region Champs
    [Header("Components")]
    [SerializeField] Inventory _inventory;
    [Header("Fields")]
    [SerializeField] private int _weaponIndex; // Index de l'arme
    [SerializeField] private int _maxAmmo; // Nombre maximum de munitions
    [SerializeField] float _fireRate;
    [Header("Cursors")]
    //[SerializeField] CursorPosition _aimCursor; // AIM CURSOR POINT
    [Header("Events")]
    [SerializeField] UnityEvent _onUsed;
    [SerializeField] UnityEvent _onFire;

    private int currentAmmo; // Munitions actuelles
    public int WeaponIndex { get => _weaponIndex; }
    public int MaxAmmo { get => _maxAmmo; }
    Coroutine ShootRoutine { get; set; }
    //Weapon weapon; // Référence au script Weapon
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    // Update is called once per frame
    #endregion
    #region Methods
    public void Use(bool action)
    {
        
        _inventory.AddWeapons(this);
        _onUsed.Invoke();
    }
    #region Unity LifeCycle
    private void Reset()
    {
        _maxAmmo = 100;
    }
    // Start is called before the first frame update
    private void Start()
    {
        currentAmmo = _maxAmmo; // Commencez avec le nombre maximum de munitions
    }
    #endregion
    #region Methods
    public int GetWeaponIndex()
    {
        return WeaponIndex;
    }

    public int GetCurrentAmmo()
    {
        return currentAmmo;
    }

    public void UseAmmo()
    {
        if (currentAmmo > 0)
        {
            currentAmmo--;
        }
    }

    public void ReloadAmmo(int _maxAmmo)
    {
        currentAmmo = _maxAmmo; // Rechargez les munitions
    }

    public void ShootStart(InputAction.CallbackContext obj)
    {
        if (ShootRoutine != null) return;
        ShootRoutine = StartCoroutine(Shoot());
        IEnumerator Shoot()
        {
            var waiter = new WaitForSeconds(_fireRate);
            while (true)
            {
                if (GetCurrentAmmo() > 0) // Vérifier s'il y a des munitions
                {
                    //Instantiate(_bulletPrefab, _bulletSpawner.position, Quaternion.identity).SetDirection(_aimCursor);
                    UseAmmo(); // Déduire une munition
                }
                yield return waiter;
            }
        }
    }
    public void ShootStop(InputAction.CallbackContext obj)
    {
        if (ShootRoutine == null) return;
        StopCoroutine(ShootRoutine);
        ShootRoutine = null;
    }
    #endregion
    #region Coroutines
    #endregion
    #endregion
    #region Coroutines
    #endregion
}
