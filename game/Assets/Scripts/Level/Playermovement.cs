using UnityEngine;


public class Playermovement : MonoBehaviour
{
	private CharacterController ch;
	public float forwardSpeed;
	public bool playerMove = true;

	public float maxSpeed;

	private Vector3 velocity;
	private int desiredlane = 1;
	public float laneDistance = 4;
	private int privlane;
	private float grav = -9.81f;
	[SerializeField] private float gravityMulti = 2.0f;


	[SerializeField] GameObject particle;

	public static int NumOfCoins;

	private void Start()
	{
		NumOfCoins = 0;

		desiredlane = Random.Range(0, 3);
		privlane = desiredlane;
		ch = GetComponent<CharacterController>();

	}

	private void Update()
	{

	
		velocity.y += grav *  Time.deltaTime;

		if (playerMove == true)
		{


			if (Input.GetKeyDown(KeyCode.D))
			{
				privlane = desiredlane;
				desiredlane++;
				if (desiredlane == 4)
				{
					desiredlane = 3;
				}
			}

			if (Input.GetKeyDown(KeyCode.A))
			{
				privlane = desiredlane;
				desiredlane--;
				if (desiredlane == -1)
				{
					desiredlane = 0;
				}
			}

			if (SwipeManager.swipeRight)
			{
				privlane = desiredlane;
				desiredlane++;
				if (desiredlane == 4)
					desiredlane = 3;
			}
			if (SwipeManager.swipeLeft)
			{
				privlane = desiredlane;
				desiredlane--;
				if (desiredlane == -1)
					desiredlane = 0;
			}
		}

	}
	private void FixedUpdate()
	{

		
		Vector3 targetPosition = transform.position.z * transform.forward + transform.position.y * transform.up;

		if (playerMove == true)
		{
			velocity.z = forwardSpeed;
			if (forwardSpeed < maxSpeed)
			{
				forwardSpeed += .01f;
			}
			ch.Move(velocity * Time.fixedDeltaTime);

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
				targetPosition += (Vector3.left * laneDistance) * -0.6f;
			}
			else if (desiredlane == 3)
			{
				targetPosition += (Vector3.left * laneDistance) * -1.8f;
			}

		}
		if (transform.position != targetPosition)
		{
			Vector3 diff = targetPosition - transform.position;
			Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
			if (moveDir.sqrMagnitude < diff.magnitude)
				ch.Move(moveDir);
			else
				ch.Move(diff);
		}

		ch.Move(velocity * Time.deltaTime);
	}




	

	private void ParticleSpawn()
	{
		particle.SetActive(true);
	}

}
