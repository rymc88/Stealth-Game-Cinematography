using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private static AudioManager _instance;
    public static AudioManager Instance { get { return _instance; } }
    

    private void Awake()
    {
        if(_instance != null && _instance != this)
        {
            Debug.LogError("Audio Manager is Null");
        }
        else
        {
            _instance = this;
        }
        
    }

    public AudioSource voiceOver;
    public AudioSource music;

    public void PlayVoiceOver(AudioClip clipToPlay)
    {
        voiceOver.clip = clipToPlay;
        voiceOver.Play();
    }

    public void PlayMusic()
    {
        music.Play();
    }

}

