using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CreditsMenuButtons : MonoBehaviour
{
    public Canvas _settingsCanvas;
    public Canvas _mainMenuCanvas;
    public Canvas _creditsCanvas;
    [Space]
    public GameObject _textCredits;

    public void Back_Button()
    {
        _settingsCanvas.gameObject.SetActive(false);
        _mainMenuCanvas.gameObject.SetActive(true);
        _creditsCanvas.gameObject.SetActive(false);
    }
}
