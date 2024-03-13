using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public Transform target;
    public float followSpeed = 5f;
    public float cameraHeight = 2f;

    void Update()
    {
        if(target != null)
        {
            Vector3 desiredPosition = target.position + new Vector3(0f, 0f, -10f);
            desiredPosition.y += cameraHeight;
            Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, followSpeed * Time.deltaTime);
            transform.position = new Vector3(smoothedPosition.x, smoothedPosition.y, transform.position.z);
        }
    }
    
    public void UpdateFollowTarget(Transform newTarget)
    {
        target = newTarget;
    }
    /*this was added due to ThrowController.cs
     *I saw the updated target for my camera was working depending on my CharacterSwitcher
     *So i grabbed the changing target in order to check if the current player is atmos */
    public Transform CurrentTarget()
    {
        return target;
    }
}
