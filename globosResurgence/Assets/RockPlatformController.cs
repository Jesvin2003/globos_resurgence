using UnityEngine;

public class RockPlatformController : MonoBehaviour
{
    public float dropSpeed = 5.0f; // Speed at which the platform drops down
    public float riseSpeed = 1.0f; // Speed at which the platform rises up
    public float dropDistance = 2.0f; // Distance the platform drops down
    public float riseDistance = 2.0f; // Distance the platform rises up

    private Vector3 initialPosition; // Initial position of the platform
    private bool isDropping = true; // Flag to indicate if the platform is dropping or rising

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        float newY;

        if (isDropping)
        {
            // Calculate the new position for dropping
            newY = Mathf.MoveTowards(transform.position.y, initialPosition.y - dropDistance, dropSpeed * Time.deltaTime);

            // Check if the platform has reached the bottom
            if (newY <= initialPosition.y - dropDistance)
            {
                isDropping = false; // Switch to rising
            }
        }
        else
        {
            // Calculate the new position for rising
            newY = Mathf.MoveTowards(transform.position.y, initialPosition.y, riseSpeed * Time.deltaTime);

            // Check if the platform has reached the top
            if (newY >= initialPosition.y)
            {
                isDropping = true; // Switch to dropping
            }
        }

        // Apply the new Y position to the platform
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }
}