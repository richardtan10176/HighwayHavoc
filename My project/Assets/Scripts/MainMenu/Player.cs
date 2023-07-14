using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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

    public GameObject gemsObj;
    public GameObject coinsObj;

    public static TextMeshProUGUI gemsText;
    public static TextMeshProUGUI coinsText;

    private void Awake()
    {
        gemsText = gemsObj.GetComponent<TextMeshProUGUI>();
        coinsText = coinsObj.GetComponent<TextMeshProUGUI>();

        gemsText.text = IAPcontroller.mainPlayer.gems.ToString();
        coinsText.text = IAPcontroller.mainPlayer.coins.ToString();
    }

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
        gemsText.text = gems.ToString();
    }
    public void addCoins(int amount)
    {
        coins += amount;
        Save();
        Debug.Log("adding");
        coinsText.text = coins.ToString();
    }
    public void removeGems(int amount)
    {
        gems -= amount;
        Save();
        gemsText.text = gems.ToString();
    }
    public void removeCoins(int amount)
    {
        coins -= amount;
        Save();
        coinsText.text = coins.ToString();
    }
}
