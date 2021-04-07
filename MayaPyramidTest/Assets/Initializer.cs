using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializer : MonoBehaviour
{
    void Start()
    {
        // Set up some PlayerPrefs for the first time - if they do not already exist.
        if (!PlayerPrefs.HasKey("sfxSliderValue"))
        {
            PlayerPrefs.SetFloat("sfxSliderValue", 0.5f);
        }
    }
}
