using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleDoorOpen : MonoBehaviour
{
    public GameObject doorLeft;
    public GameObject doorRight;
    public BoxCollider entryCollider;

    public float speed;
    private bool open;
    private bool closed;
    private bool active;

    public Vector3 openPosLeft;
    private Vector3 closedPosLeft;
    public Vector3 openPosRight;
    private Vector3 closedPosRight;

    // Start is called before the first frame update
    void Start()
    {
        entryCollider = gameObject.GetComponent<BoxCollider>();
        closedPosLeft = doorLeft.transform.localPosition;
        closedPosRight = doorRight.transform.localPosition;
        if(speed < 1)
        {
            speed = 2;
        }
        open = false;
        closed = false;
        active = false;
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
        if(open)
        {
            if (doorLeft.transform.localPosition.x > openPosLeft.x)
            {
                doorLeft.transform.Translate(Vector3.left * speed * Time.deltaTime);
            }

            if (doorRight.transform.localPosition.x < openPosRight.x)
            {
                doorRight.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
        if(closed)
        {
            if (doorLeft.transform.localPosition.x < closedPosLeft.x)
            {
                doorLeft.transform.Translate(Vector3.right * speed * Time.deltaTime);
            }

            if (doorRight.transform.localPosition.x > closedPosRight.x)
            {
                doorRight.transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
    }

    private void ToggleActive(bool b)
    {
        active = b;
    }
}
