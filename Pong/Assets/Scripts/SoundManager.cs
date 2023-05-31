using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource SFXSource;

    [Header("SFX")]
    [SerializeField] public AudioClip bounceSound;
    [SerializeField] public AudioClip pauseMenuSound;
    
    public void PlaySFX(AudioClip soundToPlay)
    {
        SFXSource.PlayOneShot(soundToPlay);
    }
}
