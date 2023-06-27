using UnityEngine;

public class Playermovement : MonoBehaviour
{
	private Rigidbody rb;
	public float forwardSpeed;
	public bool playerMove = true;
	
	public float maxSpeed;


	private int desiredlane = 1;
	public float laneDistance = 2;


	[SerializeField] private float gravityMulti = 3.0f;


	[SerializeField] GameObject particle;

	public static int NumOfCoins;

	private void Start()
	{
		NumOfCoins = 0;

		desiredlane = Random.Range(0, 3);
		rb = GetComponent<Rigidbody>();
	}

	private void Update()
	{
		rb.velocity = Vector3.forward * forwardSpeed;


		if (playerMove == true)
		{
			if (forwardSpeed < maxSpeed)
			{
			forwardSpeed += .01f;
			}


			if (Input.GetKeyDown(KeyCode.D))
			{
				desiredlane++;
				if (desiredlane == 4)
				{
					desiredlane = 3;
				}
			}

			if (Input.GetKeyDown(KeyCode.A))
			{
				desiredlane--;
				if (desiredlane == -1)
				{
					desiredlane = 0;
				}
			}

			if (SwipeManager.swipeRight)
			{
				desiredlane++;
				if (desiredlane == 4)
					desiredlane = 3;
			}
			if (SwipeManager.swipeLeft)
			{
				desiredlane--;
				if (desiredlane == -1)
					desiredlane = 0;
			}
		}

	}

	private void FixedUpdate()
	{
			float targetPosition;

			{
				if (desiredlane == 0)
				{

					targetPosition = (-1 * laneDistance) * 1.8f;
				transform.position = new Vector3(targetPosition, transform.position.y, transform.position.z);
			}
				else if (desiredlane == 1)
				{
					targetPosition = (-1 * laneDistance) * 0.6f;
				transform.position = new Vector3(targetPosition, transform.position.y, transform.position.z);
			}
				else if (desiredlane == 2)
				{
					targetPosition = (-1 * laneDistance) * -0.6f;
				transform.position = new Vector3(targetPosition, transform.position.y, transform.position.z);
			}
				else if (desiredlane == 3)
				{
					targetPosition = (-1 * laneDistance) * -1.8f;
				transform.position = new Vector3(targetPosition, transform.position.y, transform.position.z);
			}
		}
	}




	private void OnTriggerEnter(Collider other)
	{

		
		if (other.transform.tag.Equals("Obstacle"))
		{
			Time.timeScale = 0;
			forwardSpeed = 0;
			Debug.Log("Hit");
			playerMove = false;
			Invoke("ParticleSpawn", 1);

			Time.timeScale = 1;
			
		}
	}

	private void ParticleSpawn()
	{
		particle.SetActive(true);
	}

}
