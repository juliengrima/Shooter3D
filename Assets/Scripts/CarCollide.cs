using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollide : MonoBehaviour
{
    #region Champs
    [SerializeField] AudioSource _source;
    [SerializeField] AudioClip _clip;
    [SerializeField] string[] _tag;
    #endregion
    #region Unity LifeCycle
    // Start is called before the first frame update

    // Update is called once per frame

    #endregion
    #region Methods
    private void OnCollisionEnter(Collision collision)
    {
        foreach(var tag in _tag)
        {
            var who = collision.gameObject.CompareTag(tag);

            if (tag == "Player" || tag == "Enemy")
            {
                _source.PlayOneShot(_clip);
            }
        }
    }
    #endregion
    #region Coroutines
    #endregion
}
