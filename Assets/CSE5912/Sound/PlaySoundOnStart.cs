using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnStart : MonoBehaviour
{
    [SerializeField] private AudioClip clip;
    private void Start()
    {
        SoundManager.Instance.PlayEffect(clip);
    }
}
