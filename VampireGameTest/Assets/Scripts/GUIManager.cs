using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GUIManager : MonoBehaviour
{

    bool paused = false;

    public bool hasPauseMenu;
    public Canvas PauseMenu;
    bool canUseInput = true;

    private void Update()
    {
        if (hasPauseMenu && canUseInput)
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (!paused)
                {
                    paused = true;
                    CanvasActive(PauseMenu);
                    PauseTime();
                }
                else
                {
                    paused = false;
                    CanvasDeactive(PauseMenu);
                    UnpauseTime();
                }
            }
        }
    }

    public void switchScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

   public void CanvasActive(Canvas toActive)
    {
        toActive.gameObject.SetActive(true);
    }

   public void CanvasDeactive(Canvas toDeactive)
    {
        toDeactive.gameObject.SetActive(false);
    }

    public void ButtonNotInteractive(Button toAffect)
    {
        toAffect.interactable = false;
        canUseInput = false;
    }

    public void ButtonIsInteractive(Button toAffect)
    {
        toAffect.interactable = true;
        canUseInput = true;
    }

    public void PauseTime()
    {
        Time.timeScale = 0;
    }

    public void UnpauseTime()
    {
        paused = false;
        Time.timeScale = 1;
    }

    public void LeaveGame()
    {
        Application.Quit();
    }
}
