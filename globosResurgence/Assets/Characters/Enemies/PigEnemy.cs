using UnityEngine;

public class PigEnemy : MonoBehaviour
{
    public float detectionRadius = 5f;
    public float attackRange = 2f;
    public float movementSpeed = 5f;
    public float chargeCooldown = 2f;
    public float damage = 1f;
    public int maxHealth = 3;
    public float knockbackForce = 5f;

    private Transform player;
    private bool isCharging = false;
    private bool canCharge = true;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        if (!player)
        {
            FindPlayer();
            return;
        }

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRadius)
        {
            if (!isCharging && canCharge)
            {
                ChargeAtPlayer();
            }
        }
    }

    private void FindPlayer()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void ChargeAtPlayer()
    {
        Vector2 direction = (player.position - transform.position).normalized;
        transform.Translate(direction * movementSpeed * Time.deltaTime);

        if (Vector2.Distance(transform.position, player.position) <= attackRange)
        {
            // Deal damage and apply knockback
            Health playerHealth = player.GetComponent<Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage);
                Rigidbody2D playerRigidbody = player.GetComponent<Rigidbody2D>();
                if (playerRigidbody != null)
                {
                    Vector2 knockbackDirection = (player.position - transform.position).normalized;
                    playerRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);
                }
            }

            // Set charging cooldown
            isCharging = true;
            canCharge = false;
            Invoke("ResetChargeCooldown", chargeCooldown);
        }
    }


    private void ResetChargeCooldown()
    {
        isCharging = false;
        canCharge = true;
    }


    public void TakeDamage(float damageAmount)
    {
        currentHealth -= Mathf.RoundToInt(damageAmount);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        // Implement death behavior here (e.g., play death animation, destroy GameObject)
        Destroy(gameObject);
    }
}

