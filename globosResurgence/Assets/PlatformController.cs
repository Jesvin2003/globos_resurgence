
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public GameObject platform1; // Reference to the platform GameObject named "platform1"

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Animator platformAnimator = platform1.GetComponent<Animator>();

            if (platformAnimator != null)
            {
                platformAnimator.Play("platformAnimation1");
                GetComponent<BoxCollider>().enabled = false; // You can use GetComponent directly if the script is attached to the button GameObject.
            }
            else
            {
                Debug.LogError("Animator component not found on platform1!");
            }
        }
    }
}
