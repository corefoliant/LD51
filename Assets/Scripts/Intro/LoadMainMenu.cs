using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadMainMenu : MonoBehaviour
{
    public float _waitFor = 4f;

    private IEnumerator Start()
    {
        yield return new WaitForSeconds(_waitFor);
        TransitionManager.DoTransition("MainMenu");
    }
}
