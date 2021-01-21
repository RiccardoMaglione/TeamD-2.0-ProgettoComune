﻿using UnityEngine;
using System;
using UnityEngine.UI;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;
    
    /// <summary>
    /// Start the selected song
    /// </summary>
    /// <param name="name"> Name of the song</param>
    /// <param name="volume"> Volume of the song </param>
    public void Play(string name, float musicVolume, float masterVolume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        s.source.volume = musicVolume - (1 - masterVolume);
    }

    /// <summary>
    /// Stop the selected song
    /// </summary>
    /// <param name="name"> Name of the song </param>
    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Stop();
    }

    /// <summary>
    /// Change The volume of the selected song by slider
    /// </summary>
    /// <param name="name"> Name of the song </param>
    /// <param name="slider"> Slider that change the volume </param>
    public void ChangeVolume(string name, float musicVolume, float masterVolume)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.volume = musicVolume - (1 - masterVolume);
    }


    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }
            
        DontDestroyOnLoad(gameObject);
        foreach (Sound s in sounds)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volume;
            s.source.loop = s.loop;
        }

        Play("temp", PlayerPrefs.GetFloat("MusicVolume"), PlayerPrefs.GetFloat("MasterVolume"));
    }
}
