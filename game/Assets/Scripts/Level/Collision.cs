using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
	public Playermovement playermovement;
	public GameObject player;
	private void OnTriggerEnter(Collider collision)
	{
		if (collision.transform.tag.Equals("Obstacle"))
		{
			Time.timeScale = 0;
			player.GetComponent<Playermovement>().enabled = false;
			playermovement.forwardSpeed = 0;
			Debug.Log("hit");
		}
		//Debug.Log("middle");


		//Debug.Log("Hit");
		//playerMove = false;
		//Invoke("ParticleSpawn", 1);
		//Time.timeScale = 1;
	}
}

