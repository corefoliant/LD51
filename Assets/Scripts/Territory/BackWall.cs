using UnityEngine.SceneManagement;
using UnityEngine;

public class BackWall : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, Time.deltaTime * _moveSpeed);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
