using UnityEngine;
using UnityEngine.SceneManagement;

public class GamePlayScene : MonoBehaviour
{
    [SerializeField] private GameObject DeathPanel;

    public void Death()
    {
        DeathPanel.SetActive(true);
        Time.timeScale = 0;
    }
    
    public void ExitToMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
