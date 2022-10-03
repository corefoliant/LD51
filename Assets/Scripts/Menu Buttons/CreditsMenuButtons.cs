using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CreditsMenuButtons : MonoBehaviour
{
    public Canvas _settingsCanvas;
    public Canvas _mainMenuCanvas;
    public Canvas _creditsCanvas;
    [Space]
    public TMPro.TMP_Text _textCredits;
    [Space]
    public string[] _credits;
    [Space]
    public float _secondsToWait = 3f;

    private IEnumerator _changeCredits;

    public void Back_Button()
    {
        _settingsCanvas.gameObject.SetActive(false);
        _mainMenuCanvas.gameObject.SetActive(true);
        _creditsCanvas.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        if (_changeCredits != null)
            StopCoroutine(_changeCredits);
        StartCoroutine(_changeCredits = ChangeCredits());
    }

    private IEnumerator ChangeCredits()
    {
        for (int i = 0; i < _credits.Length; i++)
        {
            yield return new WaitForSeconds(_secondsToWait);
            _textCredits.text = _credits[i];
        }
    }
}
