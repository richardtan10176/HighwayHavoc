using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
	public bool hasRespawned = false;
	Playermovement playermovement;
	GameObject DeathScreen;
	GameObject respawnScreen;

    void Start()
    {
		playermovement = this.GetComponent<Playermovement>();
		DeathScreen = GameObject.Find("DeathScreen").transform.GetChild(0).gameObject;
		respawnScreen = GameObject.Find("RespawnScreen").transform.GetChild(0).gameObject;
	}
    void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.transform.tag == "Obstacle")
		{

			PlayerPrefs.SetInt("coinScore", PlayerPrefs.GetInt("coinScore") + Playermovement.NumOfCoins);
			PlayerPrefs.SetInt("score", Score.pScore);
			int randNum = Random.Range(1, 5);
			playermovement.playerMove = false;
			
			playermovement.fire.transform.position = SpawnPlayerCar.playerCar.transform.position + new Vector3(0, 0, 1);
			playermovement.explosion.transform.position = SpawnPlayerCar.playerCar.transform.position + new Vector3(0,0,5);
			playermovement.forwardSpeed = 0;
			playermovement.explosion.SetActive(true);
			playermovement.fire.SetActive(true);
			DeathScreen.SetActive(true);

			if(randNum == 3 && !hasRespawned)
            {
				respawnScreen.SetActive(true);
            }

			
		}
	}
}

