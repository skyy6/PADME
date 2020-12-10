using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    
    Transform player;
    Transform playerCamera;
    float startingTime;
    float endTime;
    float distance;
    Rigidbody rigidBody;
    Vector3 startScale;
    bool isCarrying = false;
    float power = 450f;
    float startingPower = 250f;
    bool collided = false;
    bool looking = false;
    //public Camera cam;
    //public Vector3 cameraWidthThreshold;
    //public Vector3 cameraHeightThreshold;
    Vector3 nullForce = new Vector3(0, 0, 0); 
   

    private void Start()
    {
        player = GameObject.Find("Controller").transform;
        playerCamera = GameObject.Find("Main Camera").transform;
        rigidBody = GetComponent<Rigidbody>();
        startScale = transform.localScale;


    }
    void OnCollisionEnter()
    {
        if (isCarrying)
        {
            collided = true;
            Debug.Log("Collision");
        }
    
    }
    void SizeCheck()
    {
        if(transform.tag == ("Medium Objects") && Input.GetKeyDown(KeyCode.E) && distance < 7f)
        {
            PickUpItem();
            isCarrying = true;
        }
        if (transform.tag == ("Small Objects") && Input.GetKeyDown(KeyCode.E) && distance < 4.5f)
        {
            PickUpItem();
            isCarrying = true;
        }
    }
    void PickUpItem()
    {
        transform.parent = playerCamera;
        GetComponent<Rigidbody>().useGravity = false;
        rigidBody.detectCollisions = true;
    }

private void OnMouseOver()
    {
        looking = true;
        distance = Vector3.Distance(player.position, transform.position);
        SizeCheck();


    }
 
    private float ThrowForceCalc(float pushtime)
    {
        float maxTime = 2f;
        float calcTime = Mathf.Clamp01(pushtime / maxTime);
        float force = startingPower + calcTime * power;
        return force;
    }

    void Update()
    {


        if (isCarrying) {
            Vector3 screenPos = Camera.main.WorldToScreenPoint(transform.position);
            /*if(screenPos.x > 400 || screenPos.x < 170)
            {
                transform.parent = null;
                //GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().useGravity = true;
                transform.localScale = startScale;
                isCarrying = false;
            }*/
            rigidBody.velocity = Vector3.zero;
            rigidBody.angularVelocity = Vector3.zero;
            if (Input.GetMouseButtonDown(0))
            {
                startingTime = Time.time;
            }
            if (Input.GetMouseButtonUp(0))
            {
                endTime = Time.time - startingTime;
                //GetComponent<Rigidbody>().isKinematic = false;
                GetComponent<Rigidbody>().useGravity = true;
                transform.parent = null;
                isCarrying = false;

                rigidBody.AddForce(playerCamera.forward * ThrowForceCalc(endTime));
                Debug.Log("Throw" + endTime + startingTime);

            }

            if (Input.GetKeyUp(KeyCode.E))
            {
                transform.parent = null;
               //GetComponent<Rigidbody>().isKinematic = false;
               GetComponent<Rigidbody>().useGravity = true;
                //transform.localScale = startScale;
                isCarrying = false;
            }
        }

    }
}
