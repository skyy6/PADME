using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    public CameraDetection camDetect;
    ParticleSystem sparkSystem;
    Transform sparkPos;
    bool destroyed = false;
    Camera cam;
    Light light;
    private float maxIntensity;


    void Start()
    {

        sparkSystem = gameObject.GetComponentInChildren<ParticleSystem>();
        camDetect = gameObject.GetComponentInChildren<CameraDetection>();
        light = GetComponentInChildren<Light>();
        maxIntensity = light.intensity;
        light.intensity = 0f;
        
    }

    private void Update()
    {
        if(destroyed)
        {
            light.intensity = sparkSystem.particleCount * 0.001f;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Small Objects"))
        {
            light.intensity = maxIntensity;
            sparkSystem.Play();
            destroyed = true;
            camDetect.Deactivate();
            if (gameObject.transform.childCount > 0)
            {
                cam = GetComponentInChildren<Camera>();
                cam.enabled = false;
            }
        }
    }
}
