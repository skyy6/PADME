using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorOpenRight : MonoBehaviour
{
    public GameObject door;

    public float speed;
    private bool open;
    private bool closed;
    private bool active;

    public Vector3 openPos;
    private Vector3 closedPos;

    void Start()
    {
        closedPos = door.transform.localPosition;
        if (speed < 1)
        {
            speed = 2;
        }
        open = false;
        closed = false;
        active = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Controller" && active)
        {
            open = true;
            closed = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Controller" && open == true)
        {
            closed = true;
            open = false;
        }
    }

    private void Update()
    {
        if (open)
        {
            if (door.transform.localPosition.x > openPos.x)
            {
                door.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
        if (closed)
        {
            if (door.transform.localPosition.x < closedPos.x)
            {
                door.transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
    }

    private void ToggleActive(bool b)
    {
        active = b;
    }
}
