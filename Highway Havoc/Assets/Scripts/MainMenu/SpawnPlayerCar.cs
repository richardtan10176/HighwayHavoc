using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPlayerCar : MonoBehaviour
{

    public static GameObject playerCar;
    public GameObject[] cars;
    // Start is called before the first frame update
    void Awake()
    {
        playerCar = Instantiate(cars[PlayerPrefs.GetInt("playerCar") - 1]);
        playerCar.name = "playerCar";
        playerCar.transform.localScale = new Vector3(0.75f, 0.75f, 0.75f);

        playerCar.AddComponent<Playermovement>();

        playerCar.AddComponent<CoinScore>();

        playerCar.AddComponent<CharacterController>();
        playerCar.GetComponent<CharacterController>().slopeLimit = 90;
        playerCar.GetComponent<CharacterController>().stepOffset = 0.3f;
        playerCar.GetComponent<CharacterController>().skinWidth = 0.08f;
        playerCar.GetComponent<CharacterController>().minMoveDistance = 0.001f;
        playerCar.GetComponent<CharacterController>().center = new Vector3(0, 1.5f, 0);
        playerCar.GetComponent<CharacterController>().radius = 0.04f;
        playerCar.GetComponent<CharacterController>().height = 4.83f;

        playerCar.AddComponent<BoxCollider>();
        playerCar.GetComponent<BoxCollider>().center = new Vector3(0, 0, 0);
        playerCar.GetComponent<BoxCollider>().size = new Vector3(1.5f, 1, 3.85f);

        playerCar.AddComponent<Rigidbody>();
        playerCar.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeAll;
        playerCar.GetComponent<Rigidbody>().isKinematic = false;


        playerCar.AddComponent<CollisionDetection>();




    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
