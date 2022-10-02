using UnityEngine;

public class Tile : MonoBehaviour
{
    private Mechanic _conectedMechanic;
    public float TileLentgh = 100;
    private TileSpawner _spawner;

    private void OnEnable()
    {
        _conectedMechanic = GetComponent<Mechanic>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        _conectedMechanic.Enable();
        _spawner.TileSpawn();

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
            _conectedMechanic.Disable();
    }

    public void SetSpawner(TileSpawner spawner)
    {
        _spawner = spawner;
    }

    public void SelfDestroy()
    {
        Destroy(gameObject);
    }
}
