using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayScene : MonoBehaviour
{
    public void ExitToMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
