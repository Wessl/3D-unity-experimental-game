using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*  Handles all clicking of buttons in the main menu
    E.G Play, Options, Quit
    Therefore all methods should be public so they can be accessed from UI buttons
*/
public class MainMenuButtons : MonoBehaviour
{
    public void ClickPlay()
    {
        SceneManager.LoadScene(1);
    }
}
