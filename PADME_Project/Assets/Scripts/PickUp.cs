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
        if(Input.GetKey(KeyCode.E) && distance < 3f)
        {
            transform.parent = playerCamera;
            rigidBody.isKinematic = true;
            isCarrying = true;
            

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
