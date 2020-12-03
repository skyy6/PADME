using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Locker : MonoBehaviour
{
    public GameObject door;
    public float torque;

    private void Start()
    {
        //torque = 0.5f;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.name == "Controller")
        {
            OpenDoor();
        }
    }

    private void OpenDoor()
    {
        Debug.Log("Opening");
        float turn = Input.GetAxis("Horizontal");
        //door.GetComponent<Rigidbody>().AddTorque(transform.right * torque * turn);
        door.GetComponent<Rigidbody>().AddForce(transform.right * torque);
    }
}
