
using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision)
	{
		Debug.Log("Hit");
	}
}
