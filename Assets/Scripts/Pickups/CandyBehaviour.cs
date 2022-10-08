using UnityEngine;

public class CandyBehaviour : MonoBehaviour
{
    [SerializeField] private int pointsPerCandy;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerPrefs.SetInt("Score", PlayerPrefs.GetInt("Score") + pointsPerCandy);
            Debug.Log(PlayerPrefs.GetInt("Score"));
            gameObject.SetActive(false);
        }
    }
}
