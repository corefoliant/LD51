using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsMenuButtons : MonoBehaviour
{
    public Canvas _settingsCanvas;
    public Canvas _mainMenuCanvas;
    public Canvas _creditsCanvas;
    [Space]
    public Slider _globalVolume;
    public Slider _musicVolume;
    public Slider _effectsVolume;

    private void Start()
    {
        float global;
        float music;
        float effects;

        AudioManager.GetVolume(out global, out music, out effects);

        _globalVolume.value = global;
        _musicVolume.value = music;
        _effectsVolume.value = effects;
    }

    public void Back_Button()
    {
        _settingsCanvas.gameObject.SetActive(false);
        _mainMenuCanvas.gameObject.SetActive(true);
        _creditsCanvas.gameObject.SetActive(false);
    }

    public void GlobalChanged_Slider(float value)
    {
        AudioManager.ChangeGlobalVolume(value);
    }

    public void MusicChanged_Slider(float value)
    {
        AudioManager.ChangeMusicVolume(value);
    }

    public void EffectsChanged_Slider(float value)
    {
        AudioManager.ChangeEffectsVolume(value);
    }
}
