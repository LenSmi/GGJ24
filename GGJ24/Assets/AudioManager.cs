using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{

    public AudioSource audioSource;
    public AudioClip gameTheme;
    public AudioClip incorrectSFX;
    public AudioClip correctSF;


    public void PlayMainTheme()
    {
        audioSource.clip = gameTheme;
        audioSource.Play();
    }
}
