using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    //Sound is a public class build for manager soundeffect.
    public Sound[] sounds;

    public static SoundManager instance;

    private void Awake()
    {
/*        if (instance = null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
        DontDestroyOnLoad(gameObject);*/

        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;
            s.source.pitch = s.pitch;
            s.source.loop = s.loop;
        }
    }

    //Use for later. Background music
    private void Start()
    {
        Play("BackgroundMusic");
    }

    public void Play (string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        if(s == null)
        {
            Debug.LogWarning("Sound " + name + " is not founded.");
            return;
        }
        s.source.Play();
        Debug.Log("Play sound " + name);
    }
    //How to use it.
    //FindObjectOfType<SoundManager>().Play("");
}
