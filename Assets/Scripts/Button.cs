using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Audio;

public class Button : MonoBehaviour, IInteractable
{
    #region Champs
    [SerializeField] UnityEvent _onUsed;
    [SerializeField] AudioMixer _mixer;
    #endregion
    #region Unity LifeCycle
    #endregion
    #region Methods
    public void Use(bool action)
    {

        _onUsed.Invoke();

    }
    #endregion
    #region Coroutines
    #endregion
}
