using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class Player : MonoBehaviour
{
    [SerializeField]private int moveSpeed;
    [SerializeField]private int jumpAmount;
    private bool grounded;
    private Rigidbody2D rb;
    private Vector2 moveDir;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        rb.AddForce(new Vector2(moveDir.x, 0) * moveSpeed);
    }

    void Move(InputAction.CallbackContext context){
        moveDir = context.ReadValue<Vector2>();
    }
}
