using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MySingleton<MusicManager>
{
    public AudioSource audioSource;
    public AudioClip button;
    public AudioClip plant;
    public AudioClip step;
    public AudioClip menu;
    public AudioClip level;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }
    public void PlayMenuMusic()
    {
        audioSource.clip = menu;
        audioSource.Stop();
        audioSource.Play();
    }
    public void PlayLevelMusic()
    {
        audioSource.clip = level;
        audioSource.Stop();
        audioSource.Play();
    }
}
