using MainShip;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip gameTheme;
    public AudioClip incorrectSFX;
    public AudioClip correctSF;
    public AudioMixer audioMixer;


    public void PlayMainTheme()
    {
        ChangeTempo(GameConstants.easyTempo);
        audioSource.clip = gameTheme;
        audioSource.Play();
    }

    public void ChangeTempo(float tempo)
    {
        audioSource.pitch = tempo;
    }
}
