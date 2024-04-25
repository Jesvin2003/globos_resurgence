using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }
    private GameMaster gameMaster; // Reference to GameMaster script

    private Animator animator;

    bool isDead = false; // Flag to track if the player is alive

    private void Awake()
    {
        currentHealth = startingHealth;
<<<<<<< Updated upstream
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
=======
        animator = GetComponent<Animator>();
>>>>>>> Stashed changes
    }

    public void TakeDamage(float _damage)
    {
        // If the player is already dead, exit the function
        if (isDead)
        {
            return;
        }
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        animator.SetTrigger("isTakingDamage");
        if (currentHealth <= 0)
        {
<<<<<<< Updated upstream
=======
            //death
            isDead = true;
>>>>>>> Stashed changes
            Die();
        }

    }

    void Die()
    {
<<<<<<< Updated upstream
        currentHealth = startingHealth; // Reset health
        transform.position = gameMaster.lastCheckPointPos; // Respawn at last checkpoint
        Debug.Log("Player has Died");
=======
         // Set the player as dead
        animator.SetTrigger("isDead");// Trigger the death animation
                                           // Optionally, you may want to disable player controls or any other relevant functionality here
>>>>>>> Stashed changes
    }


}
