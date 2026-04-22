using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;
    public float zSpawn = 0;
    public float tileLength = 10;
    public float numberOfTiles = 5;


    private List<GameObject> activeTiles = new();

    public Transform player;

    void Start()
    {
        for (int i = 0; i < numberOfTiles; i++)
        {
            if (i == 0) SpawnTile(0);
            else SpawnTile(Random.Range(1, tilePrefabs.Length));
        }

    }

    void Update()
    {
        if (player.position.y - 35 > zSpawn - (numberOfTiles * tileLength))
        {
            SpawnTile(Random.Range(1, tilePrefabs.Length));
            DeleteTile();
        }

    }

    public void SpawnTile(int index)
    {
        GameObject gameObj = Instantiate(tilePrefabs[index], transform.up * zSpawn, transform.rotation);
        activeTiles.Add(gameObj);
        zSpawn += tileLength;
    }


    void DeleteTile()
    {
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
    }



}
