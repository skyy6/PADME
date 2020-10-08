using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerController;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public float movementSpeed = 14f;
    public LayerMask groundMask;
    public float jumpHeight = 2.5f;


    Vector3 velocity;
    bool isGrounded;
    void Start()
    {
        
    }

    
    void Update()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        playerController.Move(move * movementSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }
}
