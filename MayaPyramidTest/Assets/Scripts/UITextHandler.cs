using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITextHandler : MonoBehaviour
{
    private TextMeshProUGUI _asteroidDestroyedText;
    [SerializeField] private AsteroidGenerator asteroidGeneratorRef;
    private int _destroyedAmount;

    private void Start()
    {
        _asteroidDestroyedText = GetComponent<TextMeshProUGUI>();
        _destroyedAmount = 0;
        UpdateAsteroidUIText();
    }

    public void UpdateAsteroidUIText()
    {
        _asteroidDestroyedText.text = _destroyedAmount + "/" + asteroidGeneratorRef.asteroidAmount;
        _destroyedAmount++;
    }
}
