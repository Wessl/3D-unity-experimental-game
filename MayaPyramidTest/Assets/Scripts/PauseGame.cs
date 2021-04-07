using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseGame : MonoBehaviour
{
    public bool gamePaused = false;
    public GameObject pauseMenu;
    
    void Update()
    {
        if (Input.GetButtonDown("Cancel"))
        {
            if (gamePaused == false)
            {
                Time.timeScale = 0;
                gamePaused = true;
                pauseMenu.SetActive(true);
            }
            else
            {
                Unpause();
            }
        }
    }

    // Unpause can be called from elsewhere, E.g by clicking "resume" button in menu
    public void Unpause()
    {
        Time.timeScale = 1;
        gamePaused = false;
        pauseMenu.SetActive(false);
    }
}
