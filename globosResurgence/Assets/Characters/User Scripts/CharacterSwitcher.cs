using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwitcher : MonoBehaviour
{
    public GameObject primaryCharacter;
    public GameObject secondaryCharacter;

    private PlayerController playerController;
    private PlayerController aiController;
    private CameraFollow cameraFollow;

    void Start()
    {
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
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            SwitchCharacter();
        }
    }

    void SwitchCharacter()
    {
        playerController.enabled = !playerController.enabled;
        aiController.enabled = !aiController.enabled;

        if (playerController.enabled)
        {
            cameraFollow.UpdateFollowTarget(primaryCharacter.transform);
        }
        else
        {
            cameraFollow.UpdateFollowTarget(secondaryCharacter.transform);
        }
        //swap characters (This is just for the menu in the GameObject CharacterSwitcher
        /*GameObject temp = playerCharacter;
        playerCharacter = aiCharacter;
        aiCharacter = temp;*/

    }
}
