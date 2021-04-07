using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundMusicOptions : MonoBehaviour
{
    private Slider _soundEffectSlider;
    private float _sfxValue;
    // Start is called before the first frame update
    void Start()
    {
        _soundEffectSlider = GetComponent<Slider>();
        // Set the current slider position to whatever the current SFX volume is
        if (PlayerPrefs.HasKey("sfxSliderValue"))
        {
            _soundEffectSlider.value = PlayerPrefs.GetFloat("sfxSliderValue");
            _sfxValue   =  _soundEffectSlider.value;
        }
    }

    void Update()
    {
        if (Math.Abs(_soundEffectSlider.value - _sfxValue) > Int32.MinValue) // This is to check if something has changed, using Int32.MinValue (0x80000000) to account for floating point comparison errors
        {
            // Value changed
            _sfxValue   = _soundEffectSlider.value;
            PlayerPrefs.SetFloat("sfxSliderValue", _sfxValue);
        }
    }
}
