using UnityEngine;
using System.Collections;

public class ButtonInteraction2 : MonoBehaviour
{
    public Transform platform; // Reference to the platform
    public float speed = 2f; // Speed of platform movement
    public float distance = 5f; // Distance to move platform

    private Vector3 initialPosition; // Initial position of the platform
    private Vector3 targetPosition; // Target position for platform movement
    private bool isActivated = false; // Flag to prevent multiple interactions

    void Start()
    {
        // Initialize initial and target positions
        initialPosition = platform.position;
        targetPosition = initialPosition + Vector3.down * distance; // Move down by distance
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // When player interacts with the button
        if (other.CompareTag("Player") && !isActivated)
        {
            isActivated = true; // Set interaction flag to true
            StartCoroutine(MovePlatform()); // Start moving the platform
        }
    }

    IEnumerator MovePlatform()
    {
        // Store start and end positions
        Vector3 start = platform.position;
        Vector3 end = targetPosition;

        // Calculate the distance to move
        float journeyLength = Vector3.Distance(start, end);
        float startTime = Time.time; // Get start time

        // Move the platform towards the target position
        while (Time.time - startTime < journeyLength / speed)
        {
            float distanceCovered = (Time.time - startTime) * speed;
            float fractionOfJourney = distanceCovered / journeyLength;
            platform.position = Vector3.Lerp(start, end, fractionOfJourney);
            yield return null; // Wait for next frame
        }

        platform.position = end; // Ensure platform reaches the target position
    }
}
