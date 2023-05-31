using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileManager : MonoBehaviour
{

    public GameObject[] tilePrefabs;

    private Transform playerTransform;
    private float Rspawn = -5.0f;
    private float tileLength = 5.0f;
    private int amnTiles = 10;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;

        for(int i = 0; i< amnTiles; i++)
		{
            SpawnTile();
		}
    }

    // Update is called once per frame
    void Update()
    {
        if(playerTransform.position.z > (Rspawn - amnTiles * tileLength))
		{
            SpawnTile();
		}
    }

    void SpawnTile(int prefabIndex = -1)
	{
        GameObject go;
        go = Instantiate(tilePrefabs[0]) as GameObject;
        go.transform.SetParent(transform);
        go.transform.position = Vector3.forward * Rspawn;
        Rspawn += tileLength;
	}
}
