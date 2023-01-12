using UnityEngine;
using System;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;
    [Space]
    public Sound[] sounds;

    private void Awake()
    {
        foreach (var sound in sounds)
        {
            sound.source = gameObject.AddComponent<AudioSource>();
            sound.source.clip = sound.clip;
            if(sound.name == "BackGroundMusic") sound.source.loop = true;
        }
    }

    private void Start()
    {
        if (instance == null) instance = this;
        Play("BackGroundMusic");
    }

    public void Play(string name)
    {
        Sound s = Array.Find(sounds, x => x.name == name) ;
        if (s != null) s.source.Play();
    }

    public void Stop(string name)
    {
        Sound s = Array.Find(sounds, x => x.name == name);
        if (s != null) s.source.Stop();
    }
}
