using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIM : MonoBehaviour
{
    #region Champs
    [SerializeField] List<GameObject> _targets;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    void Awake()
    {
        
    }
    void Start()
    {
        PickRandomTarget();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion
    #region Methods
    public void PickRandomTarget()
    {
        foreach (GameObject target in _targets)
        {
            target.SetActive(false);
        }
        //Pick random target and active 
        var randomIndex = Random.Range(0, _targets.Count);
        _targets[randomIndex].SetActive(true);
    }
    #endregion
    #region Coroutines
    #endregion
}
