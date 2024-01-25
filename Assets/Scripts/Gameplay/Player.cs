using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Events;
using UnityEngine.SceneManagement;
public class Player : MonoBehaviour
{
    [Header("Moving")]
    [SerializeField]private int moveSpeed;
    private Vector2 moveDir;
    public UnityEvent ChangedDirection;
    private bool movingRight = true;

    [Header("Jumping")]
    [SerializeField]private int jumpAmount;
    private bool grounded;
    private bool holdingJump;
    private float jumpTimer, coyoteTimer;
    [SerializeField]private float jumpDelay, coyoteTime;
    [SerializeField]private LayerMask groundLayer;
    [SerializeField]private Transform groundCheckLocation;
    [SerializeField]private float groundCheckRadius;
    private Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    { 
        //All of the different checks for jumping and moving
        GroundCheck();
        JumpCheck();
        ChangeDirection();
    }

    void FixedUpdate(){
        //Moves the player side to side
        rb.velocity = new Vector2(moveDir.x * moveSpeed, rb.velocity.y);
    }
    //Changes the direction the sprite is facing based on where you're moving
    void ChangeDirection(){
        if(moveDir.x < 0 && movingRight == true){
            movingRight = false;
            GetComponentInChildren<SpriteRenderer>().flipX = true;
            ChangedDirection.Invoke();
        }else if(moveDir.x > 0 && movingRight == false){
            movingRight = true;
            GetComponentInChildren<SpriteRenderer>().flipX = false;
            ChangedDirection.Invoke();
        }
    }
    //Checks to see if the player is on the ground; and starts coyote time when leaving the ground
    void GroundCheck(){
        bool wasOnGround = grounded;
        //Checks to see if the player is grounded using an invisible circle
        grounded = Physics2D.OverlapCircle(groundCheckLocation.position, groundCheckRadius, groundLayer);

        //Starts coyote timer if the player left the ground, not through a jump
        if(wasOnGround && !grounded && rb.velocity.y < 0.3f){
            coyoteTimer = coyoteTime;
        }
    }
    //Gets move direction
    public void Move(InputAction.CallbackContext context){
        moveDir = context.ReadValue<Vector2>();
    }
    //Takes jump input and gets ready to use it
    public void JumpStart(InputAction.CallbackContext context){
        //Starts a jump delay so you can chain your jumps easier
        if(context.action.triggered){
            jumpTimer = jumpDelay;
            holdingJump = true;
        }else if(!context.action.triggered){
            holdingJump = false;
        }
    }
    //Checks to see if its possible to jump
    void JumpCheck(){
        //Just where we lower these timers so you can't have infinite coyote time
        coyoteTimer -= Time.deltaTime;
        jumpTimer -= Time.deltaTime;

        //If the player is holding down or pressed the jump button recently, and they're considered on the ground; it activates the jump function
        if((jumpTimer > 0 || holdingJump) && (grounded || coyoteTimer > 0)){
            Jump();
        }
    }
    //Actually makes the player jump
    void Jump(){   
        coyoteTimer = 0;
        jumpTimer = 0;

        //Stops the players y velocity for a second; then jumps up
        rb.velocity = new Vector2(rb.velocity.x, 0);
        rb.AddForce(transform.up * jumpAmount, ForceMode2D.Impulse);
    }
    //Resets the round
    public void Reset(){
        SceneManager.LoadScene(1);
    }
    //Just a thing to visualize the ground check
    void OnDrawGizmos(){
        Gizmos.DrawWireSphere(groundCheckLocation.position, groundCheckRadius);
    }
}
