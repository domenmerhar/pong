using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [SerializeField] private AudioSource SFXSource;

    [Header("SFX")]
    [SerializeField] public AudioClip bounceSound;
    [SerializeField] public AudioClip pauseMenuSound;
    [SerializeField] public AudioClip scoreSound;

    [Header("Volume")]
    [SerializeField] public float bounceSoundVolume;
    [SerializeField] public float pauseMenuSoundVolume;
    [SerializeField] public float scoreSoundVolume;

    public void PlaySFX(AudioClip soundToPlay, float volume)
    {
        SFXSource.volume = volume;
        SFXSource.PlayOneShot(soundToPlay);
    }
}
