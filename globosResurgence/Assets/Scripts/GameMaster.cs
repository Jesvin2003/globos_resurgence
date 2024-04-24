using UnityEngine;

public class GameMaster : MonoBehaviour
{
    private static GameMaster instance;
    public Vector2 lastCheckPointPos;
    private GameObject atmos;
    private GameObject nimbus;
    private bool atmosDead = false;
    private bool nimbusDead = false;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }

        atmos = GameObject.Find("Atmos"); // Adjust the names as per your GameObjects
        nimbus = GameObject.Find("Nimbus"); // Adjust the names as per your GameObjects
    }

    public void PlayerDied(string playerName)
    {
        if (playerName == "Atmos")
        {
            atmosDead = true;
        }
        else if (playerName == "Nimbus")
        {
            nimbusDead = true;
        }

        if (atmosDead && nimbusDead)
        {
            RespawnPlayers();
        }
    }

    void RespawnPlayers()
    {
        atmos.transform.position = lastCheckPointPos; // Respawn Atmos at last checkpoint
        nimbus.transform.position = lastCheckPointPos; // Respawn Nimbus at last checkpoint
        atmosDead = false;
        nimbusDead = false;
    }
}
