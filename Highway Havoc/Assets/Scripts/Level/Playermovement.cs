using UnityEngine;


public class Playermovement : MonoBehaviour
{
	private CharacterController ch;
	public float forwardSpeed = 8;
	public bool playerMove = true;

	public float maxSpeed = 40f;

	private Vector3 velocity;
	private int desiredlane = 1;
	public float laneDistance = 2.15f;
	private int privlane;
	private float grav = -9.81f;
	[SerializeField] private float gravityMulti = 2.0f;


	public GameObject fire;
	public GameObject explosion;

	public static int NumOfCoins;

	private void Start()
	{
		fire = GameObject.Find("Fire").transform.GetChild(0).gameObject;
		explosion = GameObject.Find("Explosion").transform.GetChild(0).gameObject;

		fire.transform.SetParent(SpawnPlayerCar.playerCar.transform);
		explosion.transform.SetParent(SpawnPlayerCar.playerCar.transform);
		


		NumOfCoins = 0;
		playerMove = true;
		desiredlane = Random.Range(0, 3);
		privlane = desiredlane;
		ch = GetComponent<CharacterController>();

	}

	private void Update()
	{
        if (!playerMove)
        {
			velocity = Vector3.zero;
        }

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


			if (transform.position != targetPosition)
			{
				Vector3 diff = targetPosition - transform.position;
				Vector3 moveDir = diff.normalized * 30 * Time.deltaTime;
				if (moveDir.sqrMagnitude < diff.magnitude)
					ch.Move(moveDir);
				else
					ch.Move(diff);
			}

		}
		ch.Move(velocity * Time.deltaTime);

	}

}
