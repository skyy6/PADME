using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SafeHatchMover : MonoBehaviour
{
    public Vector3 startPos;
    public Vector3 openPos;
    public Vector3 backPos;
    public bool enabled;
    public bool active;
    public float speed;

    private void Start()
    {
        active = false;
        enabled = false;
    }

    private void Update()
    {
        if(active)
        {
            if(transform.localPosition.z > backPos.z)
            {
                transform.Translate(Vector3.back * (speed * 0.5f) * Time.deltaTime);
            }

            if (transform.localPosition.x < openPos.x && transform.localPosition.z < backPos.z)
            {
                transform.Translate(Vector3.right * speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Controller" && enabled)
        {
            if (Input.GetKeyUp(KeyCode.E))
            {
                Debug.Log("Hatch activated");
                active = true;
            }
        }
    }

    public void Activate(bool b)
    {
        enabled = b;
    }
}
