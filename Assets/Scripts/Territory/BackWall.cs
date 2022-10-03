using UnityEngine.SceneManagement;
using UnityEngine;

public class BackWall : MonoBehaviour
{
    [SerializeField] private float _moveSpeed;
    void FixedUpdate()
    {
        transform.position += new Vector3(0, 0, Time.deltaTime * _moveSpeed);
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            TransitionManager.DoTransition("Exnone");
        }
    }
}
