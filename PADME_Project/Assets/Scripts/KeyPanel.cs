using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPanel : MonoBehaviour
{
    public GameObject doors;
    public bool active;
    public Material lightStrip;

    private Color activeCol = new Color(0, 255, 168, 0);
    private Color deactiveCol = new Color(255, 0, 0, 0);

    private void Start()
    {
        lightStrip.SetColor("_EmissionColor", deactiveCol);
        active = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E) && other.gameObject.name == "Controller")
            //&& playerHasKeycard
        {
            active = !active;
            lightSwitch();
            ActivateDoor();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Controller")
        {
            Debug.Log("In contact with " + this.gameObject + ". Press 'E' to activate");
        }
    }

    private void lightSwitch()
    {
        if(active)
        {
            lightStrip.SetColor("_EmissionColor", activeCol);
        }
        else
        {
            lightStrip.SetColor("_EmissionColor", deactiveCol);
        }
    }

    private void ActivateDoor()
    {
        doors.SendMessage("ToggleActive", active);
    }
}
