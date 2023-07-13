using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinScore : MonoBehaviour
{
    public Transform player;
    public TextMeshProUGUI Coins;

	// Update is called once per frame
	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Coin")
		{
			Playermovement.NumOfCoins += 1;
			Destroy(other.gameObject);
			Coins.text = Playermovement.NumOfCoins.ToString();
		}
	}
}
