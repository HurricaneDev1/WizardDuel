using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private Camera cam;
    private Rigidbody2D rb;
    public bool activated = true;
    void Start()
    {
        cam = Camera.main;
        rb = GetComponent<Rigidbody2D>();
    }
    //Wraps the object to the other side when they reach the edge of the screen
    void Update()
    {
        if(activated){
             Vector3 screenPos = cam.WorldToScreenPoint(transform.position);

            float rightSideOfScreen = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).x;
            float leftSideOfScreen = cam.ScreenToWorldPoint(new Vector2(0f, 0f)).x;

            float topOfScreen = cam.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height)).y;
            float bottomOfScreen = cam.ScreenToWorldPoint(new Vector2(0f, 0f)).y;

            //Player moves through left side of the screen 
            if(screenPos.x <= 0 && rb.velocity.x < 0){
                transform.position = new Vector2(rightSideOfScreen, transform.position.y);
            }else if(screenPos.x > Screen.width && rb.velocity.x > 0){
                //Going right
                transform.position = new Vector2(leftSideOfScreen, transform.position.y);
            }

            //Bottom of screen
            if(screenPos.y <= 0 && rb.velocity.y < 0){
                transform.position = new Vector2(transform.position.x, topOfScreen);
            }else if(screenPos.y > Screen.height && rb.velocity.y > 0){
                //Going Up
                transform.position = new Vector2(transform.position.x, bottomOfScreen);
            }
        }   
    }
}
