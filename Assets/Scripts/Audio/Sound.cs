using System;
using UnityEngine;

[Serializable]
public class Sound
{
    public string name;
    public AudioClip clip;

    [HideInInspector]
    public AudioSource source;
}
