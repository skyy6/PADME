using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceElevatorConsole : MonoBehaviour
{
    public GameObject serviceElevator;

    private bool active;

    private void Start()
    {
        active = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Controller")
        {
            Debug.Log("Elevator manual controls: Keypad+ = UP || Keypad- == DOWN");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Controller")
        {
            if (Input.GetKeyDown(KeyCode.KeypadPlus))
            {
                serviceElevator.SendMessage("ToggleManual", 1);
            }

            if (Input.GetKeyDown(KeyCode.KeypadMinus))
            {
                serviceElevator.SendMessage("ToggleManual", -1);
            }
        }        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Controller")
        {
            serviceElevator.SendMessage("ToggleManual", 0);
        }
    }
}
