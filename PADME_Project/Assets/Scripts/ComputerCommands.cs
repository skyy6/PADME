using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ComputerCommands : MonoBehaviour
{
    public GameObject cmdLog;
    private TMP_Text tmp;
    private string command;

    public GameObject mainLights;
    public GameObject serviceElevator;
    public GameObject playerController;
    public FlickerController flickerController;

    private bool active;
    private bool enabled;

    private void Start()
    {
        enabled = true;
        active = false;
        tmp = cmdLog.GetComponent<TextMeshProUGUI>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Controller")
        {
            Debug.Log("To activate Cmd, press 'LeftAlt'. To exit Cmd, press 'Escape'");
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Controller")
        {
            if (Input.GetKeyDown(KeyCode.LeftAlt))
            {
                active = true;
                playerController.SendMessage("ToggleTyping", true);
            }

            if (Input.GetKeyDown(KeyCode.Escape))
            {
                active = false;
                playerController.SendMessage("ToggleTyping", false);
            }

            if(active)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.D))
                {
                    Debug.Log("Cmd active. To exit, press 'Escape'");
                }
            }
            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Controller")
        {
            active = false;
            playerController.SendMessage("ToggleTyping", false);
        }
    }

    private void Update()
    {
        if(active)
        {
            foreach (char c in Input.inputString)
            {
                if (c == '\b')
                {
                    //
                }
                else if ((c == '\n') || (c == '\r'))
                {
                    CompareInput(command);
                    tmp.text += '\n' + ">> ";
                    command = "";
                }
                else
                {
                    tmp.text += c;
                    command += c;
                }
            }
        }
    }

    private void CompareInput(string cmd)
    {
        switch(cmd)
        {
            case "toggle.lights":
                mainLights.SetActive(false);
                tmp.text += '\n' + ">> Lights toggled--";
                break;
            case "elevator.run":
                serviceElevator.SendMessage("ToggleActive", true);
                tmp.text += '\n' + ">> Service elevator running--";
                break;
            case "lockdown.true":
                tmp.text += '\n' + ">> LOCKDOWN_MODE_ACTIVATED";
                flickerController.Lockdown(true);
                break;
            case "lockdown.false":
                tmp.text += '\n' + ">> LOCKDOWN_MODE_DEACTIVATED";
                flickerController.Lockdown(false);
                break;
            default:
                break;
        }
    }

}
