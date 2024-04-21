using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    //Starting Nimbus is Primary
    public GameObject primaryCharacter;
    public GameObject secondaryCharacter;

    private PlayerController playerController;
    private PlayerController aiController;
    private CameraFollow cameraFollow;

    void Start()
    {
        //this sets the target to be the primary character for camera follow
        playerController = primaryCharacter.GetComponent<PlayerController>();
        aiController = secondaryCharacter.GetComponent<PlayerController>();
        cameraFollow = Camera.main.GetComponent<CameraFollow>();

        //User character is active while AI is inactive
        playerController.enabled = true;
        aiController.enabled = false;
        cameraFollow.UpdateFollowTarget(primaryCharacter.transform);
    }

    void Update()
    {
        //when TAB is pressed characters are switched
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        // Reset velocity of the character being switched
        if (playerController.enabled)
        {
            ResetCharacterVelocity(playerController);
            cameraFollow.UpdateFollowTarget(secondaryCharacter.transform);
        }
        else
        {
            ResetCharacterVelocity(aiController);
            cameraFollow.UpdateFollowTarget(primaryCharacter.transform);
        }

        // Toggle character controllers
        playerController.enabled = !playerController.enabled;
        aiController.enabled = !aiController.enabled;
    }

    //this is to prevent sliding when switching
    void ResetCharacterVelocity(PlayerController controller)
    {
        Rigidbody2D rb = controller.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.velocity = Vector2.zero;
        }
    }
}
