using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    public Transform target; // Reference to the boat's transform
    public float distance = 5.0f; // Distance from the target
    public float height = 2.0f; // Height above the target
    public float smoothSpeed = 5.0f; // Smoothing speed for camera movement
    public float rotationSpeed = 2.0f; // Mouse input rotation speed

    private Vector3 offset;
    private float rotationX = 0.0f;
    private float rotationY = 0.0f;

    private void Start()
    {
        offset = new Vector3(0, height, -distance);
    }

    private void LateUpdate()
    {
        if (target == null)
            return;

        // Calculate the desired camera position
        Vector3 desiredPosition = target.position + offset;

        // Smoothly move the camera towards the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
        transform.position = smoothedPosition;

        // Calculate rotation based on mouse input
        rotationX += Input.GetAxis("Mouse X") * rotationSpeed;
        rotationY += Input.GetAxis("Mouse Y") * rotationSpeed;

        // Limit the vertical rotation to avoid flipping
        rotationY = Mathf.Clamp(rotationY, -90.0f, 90.0f);

        // Rotate the camera
        transform.rotation = Quaternion.Euler(rotationY, rotationX, 0);

        // Look at the target
        transform.LookAt(target);
    }
}
