using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is my attempt to pick up and throw Nimbus from a ThrowPoint above Atmos head where his arm will hold up to throw
//Animations and the path of the throw will be implemented later
public class ThrowController : MonoBehaviour
{
    public Transform throwPoint; //GameObject that is a child of Atmos which is where he will throw Nimbus from
    public GameObject nimbus;

    //Unity editor variables
    public float throwForce;
    public float throwAngle;

    private Rigidbody2D nimbusRb;
    private bool isHoldingNimbus = false;

    void Start()
    {
        nimbusRb = nimbus.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //Input variable to pick up AND throw is T on the keyboard
        if(Input.GetKeyDown(KeyCode.T))
        {
            if (!isHoldingNimbus)
            {
                PickUpNimbus();
            }
            else
            {
                ThrowNimbus();
            }
        }
    }
    //when T is clicked, Nimbus is picked up so set bool to true, same for throw with T
    void PickUpNimbus()
    {
        isHoldingNimbus = true;
        nimbus.transform.position = throwPoint.position;
        nimbusRb.isKinematic = true; // Disable physics for throw
    }
    void ThrowNimbus()
    {
        isHoldingNimbus = false;
        nimbusRb.isKinematic = false; //turn on physics simulation

        Vector2 throwDirection = Quaternion.Euler(0, 0, throwAngle) * Vector2.right; // used to manipulate z axis for the thorwAngle
        Vector2 throwVelocity = throwDirection * throwForce;
        nimbusRb.velocity = throwVelocity;
    }
}

