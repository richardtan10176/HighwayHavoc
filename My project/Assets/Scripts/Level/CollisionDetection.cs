using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
	Playermovement playermovement;
	GameObject player;

    void Start()
    {
		player = this.gameObject;
		playermovement = this.GetComponent<Playermovement>();
    }
    void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.transform.tag == "Obstacle")
		{
			player.GetComponent<Playermovement>().enabled = false;
			playermovement.fire.transform.position = SpawnPlayerCar.playerCar.transform.position + new Vector3(0, 0, 1);
			playermovement.explosion.transform.position = SpawnPlayerCar.playerCar.transform.position + new Vector3(0,0,5);
			playermovement.forwardSpeed = 0;
			playermovement.explosion.SetActive(true);
			playermovement.fire.SetActive(true);
		}
	}
}

