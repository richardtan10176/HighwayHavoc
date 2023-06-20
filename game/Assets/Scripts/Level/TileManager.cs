using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;

    private List<GameObject> activeTiles;
    private Transform playerTransform;
    private float Rspawn = -5.0f;
    private float tileLength = 7.5f;
    private int amnTiles = 15;
    private float safeZone = 15.0f;
    private int lastPrefabIndex = 0;


    // Start is called before the first frame update
    void Start()
    {
     
        activeTiles = new List<GameObject>();
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;




        for (int i = 0; i< amnTiles; i++)
		{
            if(i < 2)
			{
                SpawnTile(0);
                SpawnTile(0);
                SpawnTile(0);
                SpawnTile(0);
            }
            else
			{
                SpawnTile();
			}
		}
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z - safeZone> (Rspawn - amnTiles * tileLength))
		{
            SpawnTile();
            DeleteTile();
		}
    }

    void SpawnTile(int prefabIndex = -1)
	{
        GameObject go;
        if (prefabIndex == -1)
        {
            go = Instantiate(tilePrefabs[RandomPrefabIndex()]) as GameObject;
        }
        else
		{
            go = Instantiate(tilePrefabs[prefabIndex]) as GameObject;
		}
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * Rspawn;
        Rspawn += tileLength;
        activeTiles.Add(go);
	}

    void DeleteTile()
	{
        Destroy(activeTiles[0]);
        activeTiles.RemoveAt(0);
	}

    private int RandomPrefabIndex()
	{
        if (tilePrefabs.Length <= 1)
		{
            return 0;
        }
            

        int randomIndex = lastPrefabIndex;

        while (randomIndex == lastPrefabIndex) {
            randomIndex = Random.Range(0, tilePrefabs.Length);
		}
        lastPrefabIndex = randomIndex;
        return randomIndex;

    }
}
