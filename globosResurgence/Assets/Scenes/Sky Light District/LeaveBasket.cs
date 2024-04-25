using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadSceneOnKeyPress : MonoBehaviour
{
    // The index of the scene to load
    public int sceneIndex;

    void Update()
    {
        // Check if the L key is pressed
        if (Input.GetKeyDown(KeyCode.L))
        {
            // Load the specified scene
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
