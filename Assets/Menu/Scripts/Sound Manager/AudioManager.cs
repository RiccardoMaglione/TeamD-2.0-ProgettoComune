using UnityEngine;
using System;

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;
    public static AudioManager instance;

    /// <summary>
    /// Start the selected song
    /// </summary>
    /// <param name="name"> Name of the song</param>
    /// <param name="volume"> Volume of the song </param>
    public void Play(string name)
    {
        Sound s = Array.Find(sounds, sound => sound.name == name);
        s.source.Play();
        if(s.type == Type.Music)
            s.source.volume = PlayerPrefs.GetFloat("MusicVolume") * PlayerPrefs.GetFloat("MasterVolume");
        else
            s.source.volume = PlayerPrefs.GetFloat("SfxVolume") * PlayerPrefs.GetFloat("MasterVolume");
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
    /// Change SFX Volume by slider
    /// </summary>
    /// <param name="name"> Name of the song </param>
    /// <param name="slider"> Slider that change the volume </param>
    public void ChangeSfxVolume()
    {
        foreach (Sound s in sounds)
        {
            if(s.type == Type.SFX)
                s.source.volume = PlayerPrefs.GetFloat("SfxVolume") * PlayerPrefs.GetFloat("MasterVolume");
        }  
    }

    /// <summary>
    /// Change Music Volume by slider
    /// </summary>
    /// <param name="name"> Name of the song </param>
    /// <param name="slider"> Slider that change the volume </param>
    public void ChangeMusicVolume()
    {
        foreach (Sound s in sounds)
        {
            if (s.type == Type.Music)
                s.source.volume = PlayerPrefs.GetFloat("MusicVolume") * PlayerPrefs.GetFloat("MasterVolume");
        }
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
            s.source.loop = s.loop;
        }

        Play("test");
    }
}
