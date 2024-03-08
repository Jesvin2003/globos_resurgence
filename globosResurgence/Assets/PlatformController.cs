using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform targetPosition;
    public float speed = 1.0f;
    public bool shouldMove = false;
    // Start is called before the first frame update
    void Update()
    {
        if (shouldMove)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetPosition.position, speed * Time.deltaTime);
        }

    }
    public void StartMoving()
    {
        shouldMove = true;
    }

    // Update is called once per frame

}
