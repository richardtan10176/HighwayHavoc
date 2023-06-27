using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public int gems;
    public int coins;
    public int car1 = 0;
    public int car2 = 0;
    public int car3 = 0;
    public int car4 = 0;
    public int car5 = 0;
    public int car6 = 0;
    public int car7 = 0;

    public GameObject gemsText;
    public GameObject coinsText;


    
    public void Save()
    {
        SaveSystem.SavePlayer(this);
    }
    public void LoadPlayer()
    {
        PlayerData data = SaveSystem.LoadPlayer();
        gems = data.gems;
        coins = data.coins;
    }
    public void addGems(int amount)
    {
        gems += amount;
        Save();

    }
    public void addCoins(int amount)
    {
        coins += amount;
        Save();   
    }
    public void removeGems(int amount)
    {
        gems -= amount;
        Save();
    }
    public void removeCoins(int amount)
    {
        coins -= amount;
        Save();
    }
}
