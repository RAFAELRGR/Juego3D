using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;
    public Sonido[] sfxSounds;
    public AudioSource sfxSource;


    public void Start()
    {
        PlayMusic("aves");
    }

    public void PlayMusic(string name)
    {
        Sonido s = Array.Find(sfxSounds,x => x.name == name );
        if( s != null )
        {
            Debug.Log("No se Encontro");
        }
        else
        {
            sfxSource.clip = s.clip;
            sfxSource.Play();
        }
    }
}
