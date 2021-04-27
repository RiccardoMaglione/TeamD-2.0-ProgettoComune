using UnityEngine;

public enum Type
{ 
    Music,
    SFX
}

[System.Serializable]
public class Sound
{
    /// <summary>
    /// Name of the clip
    /// </summary>
    public string name;

    /// <summary>
    /// Clip to play
    /// </summary>
    public AudioClip clip;


    /// <summary>
    /// Check for the loop of the Clip
    /// </summary>
    public bool loop;

    /// <summary>
    /// Type of the clip
    /// </summary>
    public Type type;

    /// <summary>
    /// AudioSource of the clip
    /// </summary>
    [HideInInspector]
    public AudioSource source;
}
