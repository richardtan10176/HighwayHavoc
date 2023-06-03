using UnityEngine;

public class Playermovement : MonoBehaviour
{
	private CharacterController controller;
	public float forwardSpeed;
	
	public float maxSpeed;

	private Vector3 direction;
	private int desiredlane = 1;
	public float laneDistance = 2;

	private void Start()
	{
		desiredlane = Random.Range(0, 3);
		controller = GetComponent<CharacterController>();
	}

	private void Update()
	{
		direction.z = forwardSpeed;

		if(forwardSpeed < maxSpeed)
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
		
	}

	private void FixedUpdate()
	{


		controller.Move(direction * Time.deltaTime);

		Vector3 targetPostion = transform.position.z * transform.forward + transform.position.y * transform.up;

		if (desiredlane == 0)
		{
			targetPostion += (Vector3.left * laneDistance) * 1.8f;
		}
		else if (desiredlane == 1)
		{
			targetPostion += (Vector3.left * laneDistance) * 0.6f;
		}
		else if (desiredlane == 2)
		{
			targetPostion += (Vector3.right * laneDistance) * 0.6f;
		}
		else if (desiredlane == 3)
		{
			targetPostion += (Vector3.right * laneDistance) * 1.8f;
		}
		transform.position = Vector3.Lerp(transform.position, targetPostion, 80 * Time.deltaTime);
		
	}

}
