using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThrowController : MonoBehaviour
{
    // Variables shown in the Unity editor
    public Transform throwPoint; // Above Atmos' head
    public GameObject atmos;
    public GameObject nimbus;

    // Variables for aiming (force and angle)
    public float throwForce;
    public float maxForce;
    public float minForce;
    public float throwAngle;
    public float maxPickupDistance; // Maximum distance for picking up Nimbus

    private bool isHoldingNimbus = false;
    private float initialGravityScale;
    private Rigidbody2D nimbusRb;
    private PlayerController playerController;

    private void Start()
    {
        nimbusRb = nimbus.GetComponent<Rigidbody2D>();
        initialGravityScale = nimbusRb.gravityScale;
        playerController = atmos.GetComponent<PlayerController>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.T) && !isHoldingNimbus)
        {
            float distanceToNimbus = Vector3.Distance(atmos.transform.position, nimbus.transform.position);

            // Check if Nimbus is within the maximum pickup distance and Atmos is the current target
            if (distanceToNimbus <= maxPickupDistance && playerController != null && playerController.enabled)
            {
                // Disable the player controller to use keys solely for aiming
                playerController.enabled = false;

                // Pick up Nimbus
                PickUpNimbus();
            }
        }
        else if (Input.GetKeyDown(KeyCode.T) && isHoldingNimbus)
        {
            // Throw Nimbus
            ThrowNimbus();

            // Re-enable the controller for Atmos
            if (playerController != null)
                playerController.enabled = true;
        }

        if (isHoldingNimbus)
        {
            // Adjust the force and angle with WASD
            AdjustAim();
        }
    }

    // Pick up Nimbus
    void PickUpNimbus()
    {
        nimbusRb.isKinematic = true;
        nimbusRb.gravityScale = 0f;
        nimbus.transform.SetParent(throwPoint);
        nimbus.transform.localPosition = Vector3.zero;
        nimbus.transform.localRotation = Quaternion.identity;

        isHoldingNimbus = true;
    }

    // Throw Nimbus
    void ThrowNimbus()
    {
        Rigidbody2D rb = nimbus.GetComponent<Rigidbody2D>();
        rb.isKinematic = false;
        rb.gravityScale = initialGravityScale;
        rb.velocity = CalculateThrowVelocity();

        isHoldingNimbus = false;
    }

    // Adjust aim
    void AdjustAim()
    {
        if (Input.GetKey(KeyCode.W) && throwForce < maxForce)
            throwForce += Time.deltaTime;
        else if (Input.GetKey(KeyCode.S) && throwForce > minForce)
            throwForce -= Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
            throwAngle = Mathf.Clamp(throwAngle + Time.deltaTime * 10, 0f, 90f);
        else if (Input.GetKey(KeyCode.D))
            throwAngle = Mathf.Clamp(throwAngle - Time.deltaTime * 10, 0f, 90f);
    }

    // Calculate velocity
    Vector2 CalculateThrowVelocity()
    {
        float radians = throwAngle * Mathf.Deg2Rad;
        Vector2 velocity = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians));
        velocity *= throwForce;
        return velocity;
    }
}
