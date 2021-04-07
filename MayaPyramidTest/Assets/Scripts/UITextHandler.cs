using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UITextHandler : MonoBehaviour
{
    private TextMeshProUGUI _asteroidDestroyedText;
    [SerializeField] private AsteroidGenerator asteroidGeneratorRef;
    [SerializeField] private PauseGame _pauseGameRef;
    private int _destroyedAmount;
    private SpaceStoryHandler spaceStoryHandler;

    private void Start()
    {
        _asteroidDestroyedText = GetComponent<TextMeshProUGUI>();
        _destroyedAmount = 0;
        UpdateAsteroidUIText();
        spaceStoryHandler = GameObject.Find("SpaceStoryHandler").GetComponent<SpaceStoryHandler>();
    }

    public void UpdateAsteroidUIText()
    {
        _asteroidDestroyedText.text = _destroyedAmount + "/" + asteroidGeneratorRef.asteroidAmount;
        _destroyedAmount++;
        // Story reason
        if (_destroyedAmount == 50)
        {
            spaceStoryHandler.DisplayNextLine();
            spaceStoryHandler.SwapTextboxAreaViz();
        } else if (_destroyedAmount == 75)
        {
            spaceStoryHandler.DisplayNextLine();
        }
    }

    public void ClickResume()
    {
        _pauseGameRef.Unpause();
    }
    
}
