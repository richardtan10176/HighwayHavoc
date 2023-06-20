using UnityEngine;

public class Playermovement : MonoBehaviour
{
	private CharacterController controller;
	public float forwardSpeed;
	public bool playerMove = true;
	
	public float maxSpeed;

	private Vector3 direction;
	private int desiredlane = 1;
	public float laneDistance = 2;

	private float gravity = -9.81f;
	[SerializeField] private float gravityMulti = 3.0f;
	private float velocity;

	[SerializeField] GameObject particle;

	public static int NumOfCoins;

	private void Start()
	{
		NumOfCoins = 0;

		desiredlane = Random.Range(0, 3);
		controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		ApplyGravity();
		direction.z = forwardSpeed;
		if(playerMove == true)
		{
			if (forwardSpeed < maxSpeed)
			{
				forwardSpeed += 0.1f * Time.deltaTime;
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
		Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

		if (desiredlane == 0)
		{
			targetPosition += (Vector3.left * laneDistance) * 1.8f;
		}
		else if (desiredlane == 1)
		{
			targetPosition += (Vector3.left * laneDistance) * 0.6f;
		}
		else if (desiredlane == 2)
		{
			targetPosition += (Vector3.right * laneDistance) * 0.6f;
		}
		else if (desiredlane == 3)
		{
			targetPosition += (Vector3.right * laneDistance) * 1.8f;
		}

		//transform.position = targetPosition;
		if (transform.position != targetPosition)
		{
			Vector3 diff = targetPosition - transform.position;
			Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
			if (moveDir.sqrMagnitude < diff.magnitude)
				controller.Move(moveDir);
			else
				controller.Move(diff);
		}

		controller.Move(direction * Time.deltaTime);
	}

	private void ApplyGravity()
	{
		if (controller.isGrounded && velocity < 0.0f) 
		{
			velocity = -1.0f;
		}
		else
		{
			velocity = gravity + gravityMulti * Time.deltaTime;
		}
		
		direction.y = velocity;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.transform.tag.Equals("Obstacle"))
		{
			Time.timeScale = 0;
			playerMove = false;
			Time.timeScale = 1;
			forwardSpeed = 0;
			Debug.Log("Hit");
			Invoke("ParticleSpawn", 1);
		}
	}

	private void ParticleSpawn()
	{
		particle.SetActive(true);
	}

}
