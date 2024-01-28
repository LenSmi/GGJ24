using MainShip;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{

    public AudioSource mainAudioSource;
    public AudioSource sfxAudioSource;
    public AudioClip gameTheme;

    public AudioClip[] farts;

    public void PlayMainTheme()
    {
        ChangeTempo(GameConstants.easyTempo);
        mainAudioSource.clip = gameTheme;
        mainAudioSource.Play();
    }

    public void ChangeTempo(float tempo)
    {
        mainAudioSource.pitch = tempo;
    }

    public void SpawnFart()
    {
        int randomIndex;

        randomIndex = Random.Range(0,farts.Length);
        sfxAudioSource.PlayOneShot(farts[randomIndex]);
    }
}
