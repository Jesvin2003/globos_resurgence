using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryMenu : MonoBehaviour
{

public GameObject inventoryMenu;

    public bool isInventory;
    // Start is called before the first frame update
    void Start()
    {
        inventoryMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.I))
        {
            if(isInventory)
            {
                ResumeGame();
            }
            else
            {
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        inventoryMenu.SetActive(true);
        Time.timeScale = 0f;
        isInventory = true;
    }

    public void ResumeGame()
    {
        inventoryMenu.SetActive(false);
        Time.timeScale = 1f;
        isInventory = false;
    }
}
