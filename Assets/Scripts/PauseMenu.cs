using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class PauseMenu : MonoBehaviour
{
    public static bool isPaused = false;
    public SteamVR_Action_Boolean activateUI;


    public GameObject pauseMenu;
    public GameObject settingsMenu;

    public GameObject deactivateLine;

    public void Start()
    {
        deactivateLine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (activateUI.stateDown)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                GamePaused();
            }
        }
    }

    public void ResumeGame()
    {
        pauseMenu.SetActive(false);
        deactivateLine.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void SettingsMenu()
    {
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void settingsReturn()
    {
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void ExitToMenu()
    {
        SceneManager.LoadScene("HVRMainMenu");
        Time.timeScale = 1f;
    }

    void GamePaused()
    {
        pauseMenu.SetActive(true);
        deactivateLine.SetActive(true);
        Time.timeScale = 0f;
        
    }
}
