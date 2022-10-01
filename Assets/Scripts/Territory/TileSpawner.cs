using UnityEngine;
using Random = UnityEngine.Random;

public class TileSpawner : MonoBehaviour
{
    [SerializeField] private Tile[] _tiles;

    private void Awake()
    {
        TileSpawn();
    }

    public void TileSpawn()
    {
        var tile = Instantiate(_tiles[Random.Range(0, _tiles.Length)],transform.GetChild(transform.childCount-1).position,Quaternion.identity);
        tile.transform.SetParent(gameObject.transform);
        tile.transform.position += new Vector3(0, 0, tile.TileLentgh);
        tile.SetSpawner(transform.GetComponent<TileSpawner>());
        if(transform.childCount >5)
            gameObject.transform.GetChild(0).GetComponent<Tile>().SelfDestroy();
    }

}
