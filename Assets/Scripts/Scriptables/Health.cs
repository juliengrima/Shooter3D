using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Health : MonoBehaviour, IHealth
{
    #region Champs
    [Header("Health")]
    [SerializeField] int _startHealth;
    [SerializeField] int _startHealthMax;

    [Header("Scores")]
    [SerializeField] int _scoreOnDeath;
    [SerializeField] int _scoreOnLife;
    [SerializeField] bool _isPlayer = false;

    [Header("Effects")]
    [SerializeField] float disableDuration = 1f;
    [SerializeField] UnityEvent _effect;

    public bool IsDammageable { get; set; }

    #endregion
    #region Coroutines

    #endregion
    #region Unity LifeCycle
    private void Reset()
    {
        _startHealth = 100;
        _startHealthMax = 100;
        _scoreOnDeath = 200;
    }
    // Start is called before the first frame update
    private void Awake()
    {
        _startHealth = _startHealthMax;

        if (_isPlayer) IsDammageable = true;
    }
    private void Start()
    {
        _effect.Invoke();
    }
    #endregion
    #region Methods
    public void TakeDamage(int amount)
    {
        if (IsDammageable == false) return;

        _startHealth -= amount;

        if (_startHealth <= 0)
        {
            if (_isPlayer == true)
            {
                //ScoreManager.Instance.DeleteScore(_scoreOnDeath * 2);
                StartCoroutine(loadingScene());
                
            }
            else
            {
                //ScoreManager.Instance.AddScore(_scoreOnDeath);
                StartCoroutine(EnableDestroyAfterDelay());
            }

            _effect.Invoke();
            
        }
    }

    public void GiveLife(int amount)
    {
        if (_startHealth > 0 && _startHealth < _startHealthMax)
        {
            _startHealth += amount;
            if (_startHealth > _startHealthMax)
            {
                _startHealth = _startHealthMax;
                //ScoreManager.Instance.AddScore(_scoreOnLife);
            }
        }

        #endregion
    }

    public IEnumerator EnableDestroyAfterDelay()
    {
        Collider2D collider = gameObject.GetComponent<Collider2D>();
        collider.enabled = false;
        yield return new WaitForSeconds(disableDuration);
        Destroy(gameObject);
    }
    public IEnumerator loadingScene()
    {
        yield return new WaitForSeconds(disableDuration);
        SceneManager.GetActiveScene();
    }
}