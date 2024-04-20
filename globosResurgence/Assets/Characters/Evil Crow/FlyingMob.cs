using UnityEngine;

public class FlyingMob : MonoBehaviour
{
    public float speed; // Speed of the flying enemy
    public bool followPlayer = false; // This will trigger the enemy to follow the player if true iff the player is in range
    public Transform startingPoint;

    // Health components
    private Health nimbusHealth;
    private Health2 atmosHealth;

    // Health of the enemy
    public int maxHearts = 3;
    private int currentHearts;
    public int damage = 1;

    // Reference to players
    private GameObject nimbusObject;
    private GameObject atmosObject;
    private GameObject activePlayer;

    void Start()
    {
        nimbusObject = GameObject.Find("Nimbus");
        atmosObject = GameObject.Find("Atmos");

        if (nimbusObject != null)
            nimbusHealth = nimbusObject.GetComponent<Health>();

        if (atmosObject != null)
            atmosHealth = atmosObject.GetComponent<Health2>();

        // Set initial active player based on the starting character
        if (GameObject.FindGameObjectWithTag("Player") == nimbusObject)
        {
            activePlayer = nimbusObject;
        }
        else if (GameObject.FindGameObjectWithTag("Player") == atmosObject)
        {
            activePlayer = atmosObject;
        }

        currentHearts = maxHearts;
    }


    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Tab))
        {
            // Toggle between Nimbus and Atmos
            if (activePlayer == nimbusObject)
            {
                activePlayer = atmosObject;
            }
            else
            {
                activePlayer = nimbusObject;
            }

            // Debug log to confirm player switch
            Debug.Log("Switched active player to: " + activePlayer.name);
        }

        if (followPlayer)
        {
            Follow();
        }
        else
        {
            ReturnToPosition();
        }

        Flip();
    }

    // This function moves the enemy
    private void Follow()
    {
        // Check if the active player is alive
        if (activePlayer != null && (activePlayer == nimbusObject ? nimbusHealth.currentHealth > 0 : atmosHealth.currentHealth2 > 0))
        {
            // Debug log to track active player while following
            Debug.Log("Following: " + activePlayer.name);

            // Move towards player
            transform.position = Vector2.MoveTowards(transform.position, activePlayer.transform.position, speed * Time.deltaTime);
        }
        else
        {
            // Player is dead or null, so stop following and return to original position
            followPlayer = false;
        }
    }


    private void DealDamage()
    {
        // Debug log to track active player when dealing damage
        Debug.Log("Dealing Damage to: " + activePlayer.name);

        // Check if the player objects and their health components are not null
        if (activePlayer == atmosObject && atmosHealth != null && atmosObject.activeSelf && atmosHealth.currentHealth2 > 0)
        {
            atmosHealth.TakeDamage(damage); // Deal damage to Atmos when targeting Nimbus
        }
        else if (activePlayer == nimbusObject && nimbusHealth != null && nimbusObject.activeSelf && nimbusHealth.currentHealth > 0)
        {
            nimbusHealth.TakeDamage(damage); // Deal damage to Nimbus when targeting Atmos
        }
    }

    // Returns enemy to the position it's guarding at initially 
    private void ReturnToPosition()
    {
        transform.position = Vector2.MoveTowards(transform.position, startingPoint.position, speed * Time.deltaTime);
    }

    // Flips the enemy to face direction of the player 
    private void Flip()
    {
        // Determine direction based on player's position
        if (transform.position.x > activePlayer.transform.position.x)
            transform.rotation = Quaternion.Euler(0, 0, 0);
        else
            transform.rotation = Quaternion.Euler(0, 180, 0);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == nimbusObject || collision.gameObject == atmosObject)
        {
            DealDamage();
        }
    }

    public void TakeDamage()
    {
        if (currentHearts > 0)
        {
            currentHearts -= 1;
            // Animation of taking damage
        }
        else
        {
            Die();
        }
    }

    private void Die()
    {
        // Death actions, animation, and drop items
        Destroy(gameObject);
    }
}
