using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFXPlayer : MonoBehaviour
{
    public AudioClip asteroidDestroyedSFX;
    public AudioSource source;

    public void PlayAsteroidDestroyedSFX()
    {
        source.PlayOneShot(asteroidDestroyedSFX);
    }
}
