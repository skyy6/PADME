using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerController;
    
    public float gravity = -9.81f;
    public Transform groundCheck;
    public Transform headCheck;
    float groundDistance = 0.2f;
    public float movementSpeed;
    public float walkingSpeed = 5f;
    public float runningSpeed = 8f;
    float originalHeight;
    public LayerMask groundMask;
    public float jumpHeight = 2.5f;
    public float fieldOfView = 60f;
    float timer = 2f;
    public int sprintTime = 800;
    float crouchingSpeed = 3f;
    Vector3 velocity;
    bool moving;
    bool isGrounded;
    bool isRunning = false;
    bool isObstructed;
    bool isCrouching;
    bool isWalking;
    public StaminaBar staminaBar;
    int maxStamina = 800;

    void Jumping()
    {
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);
        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            Debug.Log("Jump");
        }
        velocity.y += gravity * Time.deltaTime;
        playerController.Move(velocity * Time.deltaTime);
    }

    void Crouching()
    {
        playerController.height = 1f;
        isWalking = false;
        isRunning = false;
        isCrouching = true;
        
    }
    void Standing()
    {
        playerController.height = originalHeight;
        isCrouching = false;
        isWalking = true;
      
    }

    void startRunning()
    {
      
        float MaxFOV = fieldOfView + 10.0f;  //fov för mer realistisk sprint
        sprintTime--;
        isRunning = true;
        timer = 2f;

        if (Camera.main.fieldOfView < MaxFOV)
        {
            Camera.main.fieldOfView += 100 * Time.deltaTime; //increase fov
        }
    }


    void startWalking()
    {
        isRunning = false;
        isWalking = true;
        if (Camera.main.fieldOfView > fieldOfView)
        {
            Camera.main.fieldOfView -= 80 * Time.deltaTime; //decrease fov
        }


    }
    void Crouch()
    {
        isObstructed = Physics.CheckSphere(headCheck.position, groundDistance, groundMask);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            Crouching();
        }
        else if (!Input.GetKeyDown(KeyCode.LeftControl) && !isObstructed)
        {
            Standing();
        }
    }
    void Run()
    {
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.W) && sprintTime > 0)
        {
            startRunning();
        }
        else
        {
            startWalking();
            if (sprintTime < 800)
            {
                timer -= Time.deltaTime;
                if (!moving | !Input.GetKey(KeyCode.LeftShift) && timer < 0)
                {
                    sprintTime++;

                }
            }
        }
    }

    void Start()
    {
        Camera.main.fieldOfView = fieldOfView;
        staminaBar.SetMaxStamina(maxStamina);
        originalHeight = playerController.height;


    }
    void Update()
    {

        staminaBar.SetStamina(sprintTime);
        Jumping();
        Run();
        Crouch();

        //Debug.Log(movementSpeed);

        if (isWalking)
        {
            movementSpeed = walkingSpeed;
        }
        if (isCrouching)
        {
            movementSpeed = crouchingSpeed;
        }
        if (isRunning)
        {
            movementSpeed = runningSpeed;
        }


       //myText = GameObject.Find("Text").GetComponent<Text>();
        //myText.text = "Units: " + sprintTime;
        float z = Input.GetAxis("Vertical");
        float x = Input.GetAxis("Horizontal");
        if(z > 0 | x > 0)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }

        Vector3 move = transform.right * x + transform.forward * z;

        playerController.Move(move * movementSpeed * Time.deltaTime);
  
    }
}
