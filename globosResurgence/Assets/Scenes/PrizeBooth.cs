using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject dialogueBox;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Show the dialogue box
            dialogueBox.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Hide the dialogue box
            dialogueBox.SetActive(false);
        }
    }
}
