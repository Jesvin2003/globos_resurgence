using UnityEngine;

public class Health2 : MonoBehaviour
{
    [SerializeField] private float startingHealth2;
    public float currentHealth2 { get; private set; }
    private GameMaster gameMaster; // Reference to GameMaster script

    private void Awake()
    {
        currentHealth2 = startingHealth2;
        gameMaster = GameObject.FindGameObjectWithTag("GM").GetComponent<GameMaster>();
    }

    public void TakeDamage(float _damage)
    {
        currentHealth2 = Mathf.Clamp(currentHealth2 - _damage, 0, startingHealth2);

        if (currentHealth2 <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        currentHealth2 = startingHealth2; // Reset health
        transform.position = gameMaster.lastCheckPointPos; // Respawn at last checkpoint
        Debug.Log("Player 2 has Died");
    }
}
