using UnityEngine;

public class Tile : MonoBehaviour
{
    private Mechanic _conectedMechanic;
    public float TileLentgh = 100;
    private TileSpawner _spawner;

    private void OnEnable()
    {
        if (GetComponent<Mechanic>())
        {
            _conectedMechanic = GetComponent<Mechanic>();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (!other.CompareTag("Player")) return;
        if (_conectedMechanic) _conectedMechanic.Enable();
        _spawner.TileSpawn();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (_conectedMechanic) _conectedMechanic.Disable();
        }
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
