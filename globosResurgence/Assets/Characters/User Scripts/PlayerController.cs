using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //NEW
public class PlayerController : MonoBehaviour
{
    //in unity editor
    public Rigidbody2D rb;
    public float speed = 20;
    public float jumpforce = 10f;
    public Transform groundChecker;
    public float checkRadius;

    private float inputX;
    private float vertical;
    private bool isGrounded;

    private void Update()
    {
        //get inputs from keyboard
        inputX = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        //this is envision with the OnDrawGizmos funtion and can be envisioned in the scene view by manipulating radius in editor
        isGrounded = Physics2D.OverlapCircle(groundChecker.position, checkRadius);

        //this function flips player around when turning direction
        Flip();

        //JUMP
        if (vertical > 0 && Mathf.Approximately(rb.velocity.y, 0))
        {
            rb.AddRelativeForce(new Vector2(0, jumpforce), ForceMode2D.Impulse);
        }
    }

    void Flip()
    {
        //if input 0 < x that means player is moving right so keep it 
        if (inputX > 0)
        {
            if (transform.eulerAngles.y != 0)
            {
                transform.eulerAngles = new Vector3(0f, 0f, 0f);
            }
        }
        //if input 0 > x  that means the player is moving left, so rotate the GameObject 180 degrees on the y axis
        else if (inputX < 0)
        {
            if (transform.eulerAngles.y != 180f)
            {
                transform.eulerAngles = new Vector3(0f, 180f, 0f);
            }
        }


    }

    private void FixedUpdate()
    {

        rb.velocity = new Vector2(inputX * speed, rb.velocity.y);

        //this stops the player from sliding when character is switched, removes momentum
        if (inputX == 0)
        {
            //if no Input is detected the characters velocity is zero
            rb.velocity = new Vector2(0, rb.velocity.y);
        }

    }

    private void OnDrawGizmos()
    {
        if (groundChecker != null)
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(groundChecker.position, checkRadius);
        }
    }
}