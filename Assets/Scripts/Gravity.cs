using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gravity : MonoBehaviour
{
    private Rigidbody2D rb;
    [Range(0.5f, 2f)]
    public float gravity = 1;
    [SerializeField]private float terminalVelocity = -10;
    public int mass = 1;
    void Start(){
        rb = GetComponent<Rigidbody2D>();
    }
    void FixedUpdate()
    {    
        //Makes the object fall down
        rb.velocity = new Vector2(rb.velocity.x, rb.velocity.y - (gravity * mass));
        
        //Limits how fast an object can fall
        if(rb.velocity.y < terminalVelocity){
            rb.velocity = new Vector2(rb.velocity.x, terminalVelocity);
        }
    }
}
