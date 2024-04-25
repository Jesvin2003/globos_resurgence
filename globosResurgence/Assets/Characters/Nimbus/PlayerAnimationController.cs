using UnityEngine;

public class PlayerAnimationController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody2D rb;

    private PlayerController playerController;

    // Parameter names for the jumping states
    private const string IS_JUMPING_PARAM = "isJumping";
    private const string IS_FALLING_PARAM = "isFalling";
    private const string IS_LANDING_PARAM = "isLanding";
    private const string IS_GROUNDED_PARAM = "isGrounded";

    // Parameter name for the blend tree
    private const string SPEED_PARAM = "Speed";

    void Start()
    {
        // Get reference to Animator component
        animator = GetComponent<Animator>();
        // Get reference to Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        //get the player controller
        playerController = GetComponent<PlayerController>();
    }

    void Update()
    {
        // Calculate the character's speed
        float speed = Mathf.Abs(rb.velocity.x) + Mathf.Abs(rb.velocity.y);

        // Set the speed parameter in the animator
        animator.SetFloat(SPEED_PARAM, speed);

        animator.SetBool(IS_JUMPING_PARAM, playerController.isJumping);
        animator.SetBool(IS_FALLING_PARAM, playerController.isFalling);
        animator.SetBool(IS_LANDING_PARAM, playerController.isLanding);
        animator.SetBool(IS_GROUNDED_PARAM, playerController.isGrounded);
    }
}
