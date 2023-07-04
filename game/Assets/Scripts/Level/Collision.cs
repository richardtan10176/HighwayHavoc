using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collision : MonoBehaviour
{
	public Playermovement playermovement;
	public GameObject player;
	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag.Equals("Obstacle"))
		{
			
			player.GetComponent<Playermovement>().enabled = false;
			Time.timeScale = 0;
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
