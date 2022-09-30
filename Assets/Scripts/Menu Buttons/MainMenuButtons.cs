using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButtons : MonoBehaviour
{
    public Canvas _settingsCanvas;
    public Canvas _mainMenuCanvas;
    public Canvas _creditsCanvas;

    public void StartGame_Button()
    {
        // load scene here
    }

    public void Settings_Button()
    {
        _settingsCanvas.gameObject.SetActive(true);
        _mainMenuCanvas.gameObject.SetActive(false);
        _creditsCanvas.gameObject.SetActive(false);
    }

    public void Credits_Button()
    {
        _settingsCanvas.gameObject.SetActive(false);
        _mainMenuCanvas.gameObject.SetActive(false);
        _creditsCanvas.gameObject.SetActive(true);
    }
}
