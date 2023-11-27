using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 4f;
    Vector2 moveInput;
    Rigidbody2D playerBody;

    void Start()
    {
        playerBody = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    // Update is called once per frame
    void Update()
    {
        //simulating walking
        Vector2 playerVelocity = new Vector2(moveInput.x, moveInput.y) * speed; 
        playerBody.velocity = playerVelocity;
    }
}
