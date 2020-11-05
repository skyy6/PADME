using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    
    Transform player;
    Transform playerCamera;
    float startingTime;
    float endTime;
    Rigidbody rigidBody;
    Vector3 startScale;
    bool isCarrying = false;
    float power = 450f;
    float startingPower = 250f;
    bool collided = false;
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
        Debug.Log("Collision");
    }

private void OnMouseOver()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        //Debug.Log("Looking at " + transform.name + "Distance: " + distance);
        if(Input.GetKeyDown(KeyCode.E) && distance < 3f)
        {
            transform.parent = playerCamera;
            //GetComponent<Rigidbody>().useGravity = false;
            rigidBody.isKinematic = true;
            rigidBody.detectCollisions = true;
            
            isCarrying = true;
            

        }
        if(isCarrying)
        {

            if (Input.GetMouseButtonDown(0))
            {
                //StartCoroutine(ThrowCounter());
                startingTime = Time.time;
            }
            if (Input.GetMouseButtonUp(0))
            {
                endTime = Time.time - startingTime;
                GetComponent<Rigidbody>().isKinematic = false;
                //GetComponent<Rigidbody>().useGravity = true;
                transform.parent = null;
                isCarrying = false;
             
                    rigidBody.AddForce(playerCamera.forward * ThrowForceCalc(endTime));
                    Debug.Log("Throw" + endTime + startingTime);
   
            }
        }
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
            /*if (collided)  //gamla if satsen för att kolla om man nuddade något
            {
                GetComponent<Rigidbody>().isKinematic = false;
                //GetComponent<Rigidbody>().useGravity = true;
                transform.parent = null;
                isCarrying = false;
                collided = false;
            }*/
            if (Input.GetKeyUp(KeyCode.E))
            {
                transform.parent = null;
                GetComponent<Rigidbody>().isKinematic = false;
               //GetComponent<Rigidbody>().useGravity = true;
                transform.localScale = startScale;
                isCarrying = false;
            }
        }

    }
}
