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
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    public void TakeDamage(float _damage)
    {
        // If the player is already dead, exit the function
        if (isDead)
        {
            return;
        }
        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

   
        if (currentHealth <= 0)
        {
            isDead = true;
            Die();
        }

    }

    void Die()
    {
        currentHealth = startingHealth; // Reset health
        transform.position = gameMaster.lastCheckPointPos; // Respawn at last checkpoint
        Debug.Log("Player has Died");
    }


}
