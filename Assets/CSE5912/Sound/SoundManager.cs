using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    //Sound is a public class build for manager soundeffect.
    public Sound[] sounds;

    public static SoundManager instance;

    private float masterVolume = 100;
    private float musicVolume = 100;
    private float effectVolume = 100;

    private float currentMasterVolume = 100;
    private float currentMusicVolume = 100;
    private float currentEffectVolume = 100;

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

    private void Update()
    {
        if (currentMasterVolume != masterVolume)
        {
            currentMasterVolume = masterVolume;
            for(int i = 0; i < sounds.Length; i++)
            {
                if(i == 0)
                    sounds[i].source.volume = sounds[i].volume * (currentMasterVolume / 100) * (currentMusicVolume / 100);
                else
                    sounds[i].source.volume = sounds[i].volume * (currentMasterVolume / 100) * (currentEffectVolume / 100);
            }
        }

        if (currentMusicVolume != musicVolume)
        {
            currentMusicVolume = musicVolume;
            sounds[0].source.volume = sounds[0].volume * (currentMusicVolume / 100) * (currentMasterVolume / 100);
        }

        if(currentEffectVolume != effectVolume)
        {
            currentEffectVolume = effectVolume;
            for (int i = 1; i < sounds.Length; i++)
                sounds[i].source.volume = sounds[i].volume * (currentEffectVolume / 100) * (currentMasterVolume / 100);
        }
    }

    public void ModifyMasterVolume(float value)
    {
        masterVolume = value;
    }

    public void ModifyMusicVolume(float value)
    {
        musicVolume = value;
    }

    public void ModifySoundEffectVolume(float value)
    {
        effectVolume = value;
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
