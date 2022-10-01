using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class LoadMainMenuWithTheSnail : MonoBehaviour
{
    public VideoPlayer _videoPlayer;
    public float _waitAfterIntro = 1f;

    private IEnumerator Start()
    {
        Camera.main.backgroundColor = Color.white;

        _videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, "IntroYellowSnail.mp4");
        _videoPlayer.Prepare();
        yield return new WaitUntil(() => _videoPlayer.isPrepared);
        _videoPlayer.Play();
        print(_videoPlayer.isPlaying);
        yield return new WaitWhile(() => _videoPlayer.isPlaying);
        yield return new WaitForSeconds(_waitAfterIntro);

        Camera.main.backgroundColor = Color.black;

        TransitionManager.DoTransition("MainMenu");
    }

    private void Update()
    {
        if (Input.anyKeyDown)
        {
            if (_videoPlayer.isPlaying)
                _videoPlayer.Stop();
            StopAllCoroutines();
            TransitionManager.DoTransition("MainMenu");
        }
    }
}
