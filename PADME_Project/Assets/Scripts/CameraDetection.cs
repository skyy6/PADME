﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDetection : MonoBehaviour
{
    public GameObject camera;
    public Material camLight;
    private bool active;
    private bool detected;

    private Color activeCol = new Color(0, 255, 10, 0);
    private Color deactiveCol = new Color(255, 0, 0, 0);

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
            Debug.Log("Player detected by " + camera.name);
            camLight.SetColor("_EmissionColor", activeCol);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Controller" && active == true)
        {
            detected = false;
            camLight.SetColor("_EmissionColor", deactiveCol);
        }
    }

    private void Deactivate()
    {
        active = false;
    }
}