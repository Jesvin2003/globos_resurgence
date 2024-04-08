using UnityEngine;

public class CheckpointScript : MonoBehaviour
{
    public int checkpointID; // Unique ID for each checkpoint
    public bool isActivated; // Flag to indicate if the checkpoint is activated

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !isActivated)
        {
            // Activate the checkpoint and save player progress
            isActivated = true;
            SavePlayerProgress();
            Debug.Log("Checkpoint activated!");
        }
    }

    void SavePlayerProgress()
    {
        // Example: Save player position using PlayerPrefs
        PlayerPrefs.SetFloat("PlayerPositionX", transform.position.x);
        PlayerPrefs.SetFloat("PlayerPositionY", transform.position.y);
        PlayerPrefs.SetFloat("PlayerPositionZ", transform.position.z);
    }

    // Example method to load player progress from PlayerPrefs
    void LoadPlayerProgress()
    {
        if (PlayerPrefs.HasKey("PlayerPositionX") && PlayerPrefs.HasKey("PlayerPositionY") && PlayerPrefs.HasKey("PlayerPositionZ"))
        {
            Vector3 playerPosition = new Vector3(
                PlayerPrefs.GetFloat("PlayerPositionX"),
                PlayerPrefs.GetFloat("PlayerPositionY"),
                PlayerPrefs.GetFloat("PlayerPositionZ")
            );

            // Example: Set player position in the game
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            if (player != null)
            {
                player.transform.position = playerPosition;
            }
        }
    }

    }
