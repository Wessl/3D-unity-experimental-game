using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SpaceStoryHandler : MonoBehaviour
{
    [SerializeField] private string[] storySentences;
    private int _storyIndex;
    public TextMeshProUGUI storyTextObject;
    public GameObject textBoxArea;
    [SerializeField] private float _textCharPrintDelay = 0.02f;
    
    void Start()
    {
        // This may be considered really poor practice. But what do I know. 
        // Show the first bit of text after X seconds
        Invoke("DisplayNextLine", 5f);
        Invoke("SwapTextboxAreaViz", 5f);
        // The next bit after another 5
        Invoke("DisplayNextLine", 12f);
        Invoke("DisplayNextLine", 20f);
        Invoke("SwapTextboxAreaViz", 30f);
    }
    
    // Triggers the next line in the story. 
    public void DisplayNextLine()
    {
        string textToDisplay = storySentences[_storyIndex];
        
        StartCoroutine(PrintTextToTextbox(textToDisplay));
        _storyIndex++;
        if (_storyIndex == storySentences.Length)
        {
            Invoke("SwapTextboxAreaViz", 10f);
        }
    }

    IEnumerator PrintTextToTextbox(string textToDisplay)
    {
        // Remove old text
        storyTextObject.text = "";
        // Slowly print out new text
        for (int i = 0; i < textToDisplay.Length; i++)
        {
            storyTextObject.text += textToDisplay[i];
            yield return new WaitForSeconds(_textCharPrintDelay);
        }
    }

    public void SwapTextboxAreaViz()
    {
        textBoxArea.SetActive(!textBoxArea.activeSelf);
    }
}
