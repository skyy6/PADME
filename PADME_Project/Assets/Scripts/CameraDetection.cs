﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    public GameController gameController;
    public GameObject camera;
    public GameObject door;
    public Material camLight;
    private bool active;
    private bool detected;

    private Color activeCol = new Color(0, 255, 10, 0);
    private Color deactiveCol = new Color(255, 0, 0, 0);
    private Color brokenCol = new Color(0, 0, 0, 0);

    private void Start()
    {
        active = true;
        detected = false;
        camLight.SetColor("_EmissionColor", deactiveCol);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Controller" && active)
        {
            detected = true;
            gameController.PlayerDetected(detected);
            Debug.Log("Player detected by " + camera.name);
            camLight.SetColor("_EmissionColor", activeCol);
            if(door != null)
            {
                ToggleDoor(false);
            }         
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Controller" && active == true)
        {
            detected = false;
            gameController.PlayerDetected(detected);
            camLight.SetColor("_EmissionColor", deactiveCol);
            if(door != null)
            {
                ToggleDoor(true);
            }            
        }
    }

    public void Deactivate()
    {
        active = false;
    }

    public void Break()
    {
        active = false;
        camLight.SetColor("_EmissionColor", brokenCol);
        ToggleDoor(true);
    }

    private void ToggleDoor(bool b)
    {
        door.SendMessage("ToggleActive", b);
    }
}
