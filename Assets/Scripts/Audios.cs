using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Audios : MonoBehaviour
{
    #region Champs
    [Header("Sources")]
    [SerializeField] AudioSource _source; //Give an audio source to play clips
    [Header("Clips Audio")]
    [SerializeField] AudioClip _audioJump;

    public AudioClip AudioJump { get => _audioJump; }
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update
    void Awake()
    {

    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    #endregion
    #region Methods
    internal void Jump()
    {
        _source.PlayOneShot(_audioJump);
    }
    #endregion
    #region Coroutines
    #endregion
}
