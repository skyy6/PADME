using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    ParticleSystem sparkSystem;
    Transform sparkPos;
    bool destroyed = false;
    Camera cam;


    void Start()
    {

        sparkSystem = gameObject.GetComponentInChildren<ParticleSystem>();
        
    }
    private void OnCollisionEnter(Collision collision)
    {
        sparkSystem.Play();
        destroyed = true;
        if(gameObject.transform.childCount > 0)
        {
            cam = GetComponentInChildren<Camera>();
            cam.enabled = false;
        }


    }

}
