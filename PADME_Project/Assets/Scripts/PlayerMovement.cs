using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController playerController;
    
 
    [Header("Transforms")]
    public Transform groundCheck;
    public Transform headCheck;
    public Transform player;
    public Camera mainCam;

    [Header("Camera")]
    public float fieldOfView = 60f;

    [Header("Jumping")]
    public LayerMask groundMask;
    public float jumpHeight = 2.5f;
    float groundDistance = 0.2f;
    public float gravity = -9.81f;
    float originalOffset;
    Vector3 velocity;

    [Header("Movement")]
    public float movementSpeed;
    public float walkingSpeed = 5f;
    public float runningSpeed = 8f;
    float crouchingSpeed = 3f;
    float timer = 2f;
    public float sprintTime = 800;
    bool moving;
    bool isGrounded;
    bool isRunning = false;
    bool isObstructed;
    bool isCrouching;
    bool isWalking;
    bool infiniteRun;
    public StaminaBar staminaBar;
    int maxStamina = 800;

    [Header("Crouching")]
    public float standingHeight = 2.94f;
    public float standingOffset = 1f;
    public float standingModelHeight = 1;
    public float crouchingModelHeight = 0.5f;
    public float crouchingHeight = 2;
    public float crouchingOffset = 0.5f;
    public float crouchSpeed = 0.3f;
    float heightVel;
    float offsetVel;
    float modelVel;
    float cameraVel;
    float targetOffset;
    float targetHeight;
    float targetModelHeight;
    float targetCameraHeight;
    public float standingCameraHeight = 1.75f;
    public float crouchingCameraHeight = 0.75f;

    private bool typing;

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


    void startRunning()
    {
      
        float MaxFOV = fieldOfView + 10.0f;  //fov för mer realistisk sprint
        sprintTime-=200f * Time.deltaTime;
        isRunning = true;
        timer = 2f;

        if (Camera.main.fieldOfView < MaxFOV)
        {
            Camera.main.fieldOfView += 100 * Time.deltaTime; //increase fov
        }
    }
    void getInfiniteRun()
    {
        if (Input.GetKey(KeyCode.CapsLock))
        {
            infiniteRun = !infiniteRun;
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
    void StandingState()
    {
        isObstructed = Physics.CheckSphere(headCheck.position, groundDistance, groundMask);
        if (Input.GetKey(KeyCode.LeftControl))
        {
            targetHeight = crouchingHeight;
            targetOffset = crouchingOffset;
            targetModelHeight = crouchingModelHeight;
            targetCameraHeight = crouchingCameraHeight;
            //isWalking = false;
            //isRunning = false;
            isCrouching = true;

        }
        if(Input.GetKeyUp(KeyCode.LeftControl) && isObstructed)
        {
            isCrouching = true;
        }

        if (!isObstructed)
        {
            playerController.height = Mathf.SmoothDamp(playerController.height, targetHeight, ref heightVel, crouchSpeed);
            var center = playerController.center;
            center.y = Mathf.SmoothDamp(center.y, targetOffset, ref offsetVel, crouchSpeed);
            playerController.center = center;

            var size = player.localScale;
            size.y = Mathf.SmoothDamp(size.y, targetModelHeight, ref modelVel, crouchSpeed);
            player.localScale = size;

            var camPos = mainCam.transform.localPosition;
            camPos.y = Mathf.SmoothDamp(camPos.y, targetCameraHeight, ref cameraVel, crouchSpeed);
            mainCam.transform.localPosition = camPos;
       
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
                    sprintTime+=200 * Time.deltaTime;

                }
            }
        }
    }

    void Start()
    {
        Camera.main.fieldOfView = fieldOfView;
        staminaBar.SetMaxStamina(maxStamina);
        originalOffset = playerController.stepOffset;
        typing = false;
        

    }
    void Update()
    {
        if(!Input.GetKeyDown(KeyCode.LeftControl) && !isObstructed){
            isCrouching = false;
        }

        staminaBar.SetStamina(sprintTime);
        Jumping();
        Run();

        targetHeight = standingHeight;
        targetOffset = standingOffset;
        targetModelHeight = standingModelHeight;
        targetCameraHeight = standingCameraHeight;

        StandingState();
        getInfiniteRun();




        //Debug.Log(movementSpeed);
        if (infiniteRun)
        {
            sprintTime = 20000;
        }



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
        if (!isGrounded)
        {
           // playerController.stepOffset = 0f;

        }
        else
        {
            playerController.stepOffset = originalOffset;
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

        if(!typing)
        {
            Vector3 move = transform.right * x + transform.forward * z;

            playerController.Move(move * movementSpeed * Time.deltaTime);
        }        
  
    }

    private void ToggleTyping(bool b)
    {
        typing = b;
    }

}

