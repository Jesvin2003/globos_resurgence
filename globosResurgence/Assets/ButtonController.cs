using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonController : MonoBehaviour
{
    public PlatformController platformController;

    void onTriggerEnter(Collider other)
    {
        if(other.CompareTag("Numbus"))
        {
            platformController.StartMoving();
        }

    }
   
}
