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
}
