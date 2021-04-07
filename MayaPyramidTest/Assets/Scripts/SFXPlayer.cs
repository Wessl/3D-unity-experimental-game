using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioClip asteroidDestroyedSFX;
    public AudioSource source;

    private float _sfxVolume;

    void Start()
    {
        _sfxVolume = PlayerPrefs.GetFloat("sfxSliderValue");
    }

    public void PlayAsteroidDestroyedSFX()
    {
        _sfxVolume = PlayerPrefs.GetFloat("sfxSliderValue");
        source.PlayOneShot(asteroidDestroyedSFX, _sfxVolume);
    }
}
