using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class GamePlayScene : MonoBehaviour
{
    [SerializeField] private Mechanic[] _mechanics;
    private Mechanic lastMechanic;
    private void Start()
    {
        PlayerPrefs.SetInt("Score", 0);
        StartCoroutine(RandomMechanic());
    }

    IEnumerator RandomMechanic()
    {
        yield return new WaitForSeconds(10);
        if(lastMechanic != null)
            lastMechanic.Disable();
        var num = Random.Range(0, _mechanics.Length);
        lastMechanic = _mechanics[num];
        lastMechanic.Enable();
        StartCoroutine(RandomMechanic());
    }

    public void ExitToMenu()
    {
        TransitionManager.DoTransition("MainMenu");
    }

    public void Restart()
    {
        TransitionManager.DoTransition("TestScenePlayer");
    }
    
    
    
}
