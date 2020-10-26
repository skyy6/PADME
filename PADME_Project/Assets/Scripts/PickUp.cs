using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    
    Transform player;
    Transform playerCamera;
    Rigidbody rigidBody;
    Vector3 startScale;
    bool isCarrying = false;
    float power = 250f;
   

    private void Start()
    {
        player = GameObject.Find("Controller").transform;
        playerCamera = GameObject.Find("Main Camera").transform;
        rigidBody = GetComponent<Rigidbody>();
        startScale = transform.localScale;
       

    }

    private void OnMouseOver()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        //Debug.Log("Looking at " + transform.name + "Distance: " + distance);
        if(Input.GetKeyDown(KeyCode.E) && distance < 3f)
        {
            transform.parent = playerCamera;
            rigidBody.isKinematic = true;
            isCarrying = true;
            

        }
        if(isCarrying)
        {
            if (Input.GetMouseButtonDown(0))
            {
                GetComponent<Rigidbody>().isKinematic = false;
                transform.parent = null;
                isCarrying = false;
                rigidBody.AddForce(playerCamera.forward * power);
                Debug.Log("Throw");
                
            }
            
            
        }


    }

    void Update()
    {
        if (isCarrying) {
            if (Input.GetKeyUp(KeyCode.E))
            {
                transform.parent = null;
                GetComponent<Rigidbody>().isKinematic = false;
                transform.localScale = startScale;
                isCarrying = false;
            }
        }

    }
}
