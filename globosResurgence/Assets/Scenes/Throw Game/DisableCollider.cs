using UnityEngine;

public class DisableColliderOnBottomCollision : MonoBehaviour
{
    private Collider2D myCollider; // Reference to the collider component

    private void Start()
    {
        // Get the collider component attached to this GameObject
        myCollider = GetComponent<Collider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision occurred from the bottom (collision normal pointing downwards)
        if (collision.contacts[0].normal.y < 0)
        {
            // Disable the collider
            myCollider.enabled = false;

            // Invoke a method to enable the collider after a delay
            Invoke("EnableCollider", 1f); // Adjust the delay as needed
        }
    }

    private void EnableCollider()
    {
        // Enable the collider after the delay
        myCollider.enabled = true;
    }
}
