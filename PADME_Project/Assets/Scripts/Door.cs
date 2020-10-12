using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float speed;
    private bool triggered = false;

    public Vector3 openPosition;
    private Vector3 closedPosition;

    void openObject()
    {
        Debug.Log("Opening");
        triggered = true;
    }

    void Start()
    {
        closedPosition = transform.position;
    }

    private void Update()
    {
        if(triggered)
        {
            if (transform.position.z > openPosition.z)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }                   
    }
}
