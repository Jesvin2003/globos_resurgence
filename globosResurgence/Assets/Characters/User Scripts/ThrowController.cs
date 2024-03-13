using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//this is my attempt to pick up and throw Nimbus from a ThrowPoint above Atmos head where his arm will hold up to throw
//Animations and the path of the throw will be implemented later
public class ThrowController : MonoBehaviour
{
    //Variables shown in the unity editor
    public Transform throwPoint; //above atmos head
    public GameObject atmos;
    public GameObject nimbus;
    //these are all for aiming (force and angle)
    public float throwForce;
    public float maxForce;
    public float minForce;
    public float throwAngle;

    private bool isHoldingNimbus = false;
    private float initialGravityScale;
    private Rigidbody2D nimbusRb;

    //CameraFollow script in order to get the current target based on character switching
    private CameraFollow cameraFollow;
    private Transform target;

    void Start()
    {
        nimbusRb = nimbus.GetComponent<Rigidbody2D>();
        initialGravityScale = nimbusRb.gravityScale;

        cameraFollow = FindObjectOfType<CameraFollow>();
    }

    void Update()
    {
        //grab the target from the CameraFollow script
        target = cameraFollow.CurrentTarget();

        /*debugging
        if(target != null)
        {
            Debug.Log("Target found: " + target.name);
        }

        else
        {
            Debug.Log("No target found");
        }
        */

        //check if the targetis Atmos, if true then allow the user to use T 
        if(target != null && target.gameObject == atmos)
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                if (!isHoldingNimbus)
                {
                    //disable the player controller to be able to use keys for soley aiming
                    PlayerController playerController = atmos.GetComponent<PlayerController>();

                    if(playerController!= null) 
                    {
                        playerController.enabled = false;
                    }

                    //pick nimbus up
                    nimbusRb.isKinematic = true;
                    nimbusRb.gravityScale = 0f; //make him unmovable until he is released
                    nimbus.transform.SetParent(throwPoint);
                    nimbus.transform.localPosition = Vector3.zero; //position at throw point
                    nimbus.transform.localRotation = Quaternion.identity;

                    isHoldingNimbus = true;
                }
                //inverse of picking up for the rigidbody
                else
                {
                    //Throw Nimbus
                    Rigidbody2D rb = nimbus.GetComponent<Rigidbody2D>();
                    rb.isKinematic = false;
                    rb.gravityScale = initialGravityScale;
                    rb.velocity = CalculateThrowVelocity();
                    isHoldingNimbus = false;

                    //reenable the controller for Atmos
                    PlayerController playerController = atmos.GetComponent<PlayerController>();
                    if (playerController != null)
                        playerController.enabled = true;
                }
            }
        }

        if (isHoldingNimbus)
        {
            //adjust the force and angle with WASD
            if (Input.GetKey(KeyCode.W) && throwForce < maxForce)
                throwForce += Time.deltaTime;
            else if(Input.GetKey(KeyCode.S) && throwForce > minForce)
                throwForce -= Time.deltaTime;

            if (Input.GetKey(KeyCode.A))
                throwAngle = Mathf.Clamp(throwAngle + Time.deltaTime * 10, 0f, 90f);
            else if (Input.GetKey(KeyCode.D))
                throwAngle = Mathf.Clamp(throwAngle - Time.deltaTime * 10, 0f, 90f);
        }
    }

    //caculate velocity, found on unity forums

    Vector2 CalculateThrowVelocity()
    {
        float radians = throwAngle * Mathf.Deg2Rad;
        Vector2 velocity = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
        velocity *= throwForce;
        return velocity;
    }
}

