using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneOnTrigger : MonoBehaviour
{
    // The index of the scene to load
    public int sceneIndex;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Check if the collider that entered is tagged as "Player"
        if (other.CompareTag("Player"))
        {
            // Load the scene by index
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
