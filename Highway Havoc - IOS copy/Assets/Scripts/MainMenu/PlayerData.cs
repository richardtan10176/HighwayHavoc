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
    public int car8 = 0;
    public int car9 = 0;
    public int car10 = 0;
    public int car11 = 0;
    public int car12 = 0;
    public int car13 = 0;
    public int car14 = 0;
    public int car15 = 0;

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
        car8 = player.car8;
        car9 = player.car9;
        car10 = player.car10;
        car11 = player.car11;
        car12 = player.car12;
        car13 = player.car13;
        car14 = player.car14;
        car15 = player.car15;
    }
}
