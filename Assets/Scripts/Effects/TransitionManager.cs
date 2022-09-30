using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TransitionManager : MonoBehaviour
{
    public float _fadeSpeed = 0.01f;
    public Color _fadeColor = Color.black;

    private static Image _fadeImage;
    private static Coroutine _currentTransition;

    private static TransitionManager instance;

    private void Start()
    {
        instance = this;
        DontDestroyOnLoad(this);

        _fadeImage = GetComponentInChildren<Image>();
    }

    public static void DoTransition(string toScene)
    {
        if (_currentTransition != null)
            instance.StopCoroutine(_currentTransition);
        _currentTransition = instance.StartCoroutine(DoTransitionOnScene(toScene));
    }

    private static IEnumerator DoTransitionOnScene(string name)
    {
        print("fade is now");

        while (_fadeImage.color.a < 1f)
        {
            _fadeImage.color = new Color(instance._fadeColor.r, instance._fadeColor.g, instance._fadeColor.b, _fadeImage.color.a + instance._fadeSpeed);
            yield return new WaitForEndOfFrame();
        }
        yield return new WaitForEndOfFrame();

        print("scene loading");
        AsyncOperation ao = SceneManager.LoadSceneAsync(name);
        ao.allowSceneActivation = false;
        yield return new WaitUntil(() => ao.progress > 0.8f);
        ao.allowSceneActivation = true;

        while (_fadeImage.color.a > 0f)
        {
            _fadeImage.color = new Color(instance._fadeColor.r, instance._fadeColor.g, instance._fadeColor.b, _fadeImage.color.a - instance._fadeSpeed);
            yield return new WaitForEndOfFrame();
        }

        print("fade is done");
        yield return new WaitForEndOfFrame();
    }
}
