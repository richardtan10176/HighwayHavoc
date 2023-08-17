using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
    //public Transform player;
    TextMeshProUGUI Coins;
    void Start()
    {
        Coins = GameObject.Find("Coins").GetComponent<TextMeshProUGUI>();
		
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Coin")
		{
			Playermovement.NumOfCoins += 1;
			AudioManager.instance.Play("Coins");
			Destroy(other.gameObject);
			Coins.text = Playermovement.NumOfCoins.ToString();
		}
	}
}
