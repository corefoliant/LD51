using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayScene : MonoBehaviour
{
    public void ExitToMenu()
    {
        TransitionManager.DoTransition("MainMenu");
    }

    public void Restart()
    {
        TransitionManager.DoTransition("TestScenePlayer");
    }
}
