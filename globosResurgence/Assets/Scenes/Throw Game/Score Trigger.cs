using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class BoxCollider2DTrigger : MonoBehaviour
{
    public int pointsToAdd = 10; // Points to add when triggered
    public float delay = 0.4f; // Delay in seconds before score can be added again

    private ScoringSystem scoringSystem; // Reference to the scoring system script
    private bool canAddScore = true; // Flag to control if score can be added

    void Start()
    {
        scoringSystem = FindObjectOfType<ScoringSystem>(); // Find the scoring system script in the scene
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && canAddScore)
        {
            scoringSystem.AddScore(pointsToAdd); // Add points to the score when the trigger is entered
            canAddScore = false; // Set flag to false to prevent adding score again immediately
            StartCoroutine(EnableScoreAdding()); // Start coroutine to enable score adding after delay
        }
    }

    IEnumerator EnableScoreAdding()
    {
        yield return new WaitForSeconds(delay); // Wait for the specified delay
        canAddScore = true; // Set flag to true to allow adding score again
    }
}
