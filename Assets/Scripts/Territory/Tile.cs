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
        _spawner.TileSpawn();
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
