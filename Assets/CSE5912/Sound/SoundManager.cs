using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public static SoundManager Instance;

    [SerializeField] private AudioSource  _effectSource,_musicSource;

    private void Awake()
    {
        if(Instance = null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlayEffect(AudioClip clip)
    {
        _effectSource.PlayOneShot(clip);
    }
}
