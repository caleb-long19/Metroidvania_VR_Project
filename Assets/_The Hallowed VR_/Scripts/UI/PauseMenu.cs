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
    public GameObject controlsMenu;

    public GameObject deactivateLine;

    public void Start()
    {
        //deactivate the pause menu line renderer
        deactivateLine.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //If button press is detected, pause game if not paused else pause the time and activate pause ui
        if (activateUI.stateDown)
        {
            if (isPaused)
            {
                ResumeGame();
            }
            else
            {
                if (Time.timeScale == 0f)
                {
                    Debug.Log("Game is paused");
                }
                else
                {
                    GamePaused();
                }
            }
        }
    }

    public void ResumeGame()
    {
        //If resume button is press, disable the pause menu, resume time and set bool to false
        pauseMenu.SetActive(false);
        deactivateLine.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }

    public void SettingsMenu()
    {
        //If settings button is press, disable the pause menu ui and actiavte the settings ui
        pauseMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    public void settingsReturn()
    {
        //If settings return button is pressed, enable pause menu and disable settings menu
        pauseMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }

    public void ControlsMenu()
    {
        //If controls button is pressed, enable controls menu and disable pause menu
        pauseMenu.SetActive(false);
        controlsMenu.SetActive(true);
    }

    public void controlsReturn()
    {
        //If controls return button is pressed, enable pause menu and disable controls menu
        pauseMenu.SetActive(true);
        controlsMenu.SetActive(false);
    }

    public void ExitToMenu()
    {
        //if exit button is pressed, load the menu scene and resume the time scale
        SceneManager.LoadScene("HVRMainMenu");
        Time.timeScale = 1f;
    }

    void GamePaused()
    {
        //When the game is pause, actiavte the pause menu and actiavte the line rendere, pause time
        pauseMenu.SetActive(true);
        deactivateLine.SetActive(true);
        Time.timeScale = 0f;
    }
}
