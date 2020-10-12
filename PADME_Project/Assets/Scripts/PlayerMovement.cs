using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerController;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.2f;
    public float movementSpeed;
    public float walkingSpeed = 6f;
    public float runningSpeed = 14f;
    public LayerMask groundMask;
    public float jumpHeight = 2.5f;
    public float fieldOfView = 60f;
    public float x = 0.5f;

    void jumping()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
    }

    void run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W))
        {
            //isRunning = true;
            float maxFOV = fieldOfView + 10.0f;  //fov för mer realistisk sprint
            movementSpeed = runningSpeed;

            if (Camera.main.fieldOfView < maxFOV)
            {
                Camera.main.fieldOfView += 100 * Time.deltaTime; //increase fov
            }
 
      }
        else
        {
            movementSpeed = walkingSpeed;
            if (Camera.main.fieldOfView > fieldOfView)
            {
                Camera.main.fieldOfView -= 80 * Time.deltaTime; //decrease fov
            }
    


        }
        //Debug.Log(Camera.main.fieldOfView);
    }
    Vector3 velocity;
    bool isGrounded;
    //bool isRunning = false;
    void Start()
    {
        Camera.main.fieldOfView = fieldOfView;
        
    }

    
    void Update()
    {
        jumping();
        run();

        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");

        Vector3 move = transform.right * x + transform.forward * z;
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("Jump");
        }

        playerController.Move(move * movementSpeed * Time.deltaTime);
        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }
}
