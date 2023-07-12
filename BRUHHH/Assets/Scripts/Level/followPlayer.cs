
using UnityEngine;

public class followPlayer : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    public float smoothSpeed = 0.125f;

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 desiredPosition = player.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
