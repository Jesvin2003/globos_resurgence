using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnKeyPress : MonoBehaviour
{
    // The index of the scene to load
    public int sceneIndex;

    // Static variable to store the player's position
    private static Vector3 playerPosition;

    // Flag to track whether the player is inside the collider
    private bool playerInsideCollider = false;

    void Update()
    {
        // Check if the player pressed the 'E' key and is inside the collider
        if (playerInsideCollider && Input.GetKeyDown(KeyCode.E))
        {
            // Save the player's current position before loading a new scene
            playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;

            // Load the scene if a scene index is assigned
            if (sceneIndex >= 0 && sceneIndex < SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(sceneIndex);
            }
            else
            {
                Debug.LogError("Invalid scene index assigned!");
            }
        }
    }

    // Triggered when another Collider2D enters this object's collider
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the object entering the collider is the player
        if (other.CompareTag("Player"))
        {
            // Set the flag to true
            playerInsideCollider = true;
        }
    }

    // Triggered when another Collider2D exits this object's collider
    void OnTriggerExit2D(Collider2D other)
    {
        // Check if the object exiting the collider is the player
        if (other.CompareTag("Player"))
        {
            // Set the flag to false
            playerInsideCollider = false;
        }
    }

    // Method to get the player's last position
    public static Vector3 GetPlayerLastPosition()
    {
        return playerPosition;
    }
}
