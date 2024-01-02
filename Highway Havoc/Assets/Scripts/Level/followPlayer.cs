
using UnityEngine;

public class followPlayer : MonoBehaviour
{

    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    private void Start()
    {
    }
    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = SpawnPlayerCar.playerCar.transform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
