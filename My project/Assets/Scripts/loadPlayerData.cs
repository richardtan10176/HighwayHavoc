using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class loadPlayerData : MonoBehaviour
{
    // Start is called before the first frame update
    public static int gemsAmount;
    public static Player player;
    PlayerData loadedData;
    void Start()
    {
        loadedData = SaveSystem.LoadPlayer();
        gemsAmount = loadedData.gems;
        Debug.Log(gemsAmount);
    }
}
