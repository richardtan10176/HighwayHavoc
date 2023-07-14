using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int gems = 0;
    public int coins = 0;

    public int car1 = 0;
    public int car2 = 0;
    public int car3 = 0;
    public int car4 = 0;
    public int car5 = 0;
    public int car6 = 0;
    public int car7 = 0;
        
    public PlayerData (Player player)
    {
        gems = player.gems;
        coins = player.coins;

        car1 = player.car1;
        car2 = player.car2;
        car3 = player.car3;
        car4 = player.car4;
        car5 = player.car5;
        car6 = player.car6;
        car7 = player.car7;

    }
}
