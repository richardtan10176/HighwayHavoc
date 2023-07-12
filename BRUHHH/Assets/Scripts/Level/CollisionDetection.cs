using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionDetection : MonoBehaviour
{
	public Playermovement playermovement;
	public GameObject player;
	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.transform.tag == "Obstacle")
		{
			player.GetComponent<Playermovement>().enabled = false;
			playermovement.forwardSpeed = 0;
			playermovement.particle.SetActive(true);
		}
	}
}

