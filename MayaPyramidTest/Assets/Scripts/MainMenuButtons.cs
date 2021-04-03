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
    public Animator transition;
    public void ClickPlay()
    {
        StartCoroutine(LoadAfterTime(1, 0.5f));
    }

    IEnumerator LoadAfterTime(int lvlIndex, float time)
    {
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(time);
        SceneManager.LoadScene(lvlIndex);
    }
}
