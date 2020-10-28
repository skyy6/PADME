using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    GameObject sparkSystem;


    void Start()
    {
        sparkSystem = GameObject.Find("Sparks");
    }
    private void OnCollisionEnter(Collision collision)
    {
        sparkSystem.GetComponent<ParticleSystem>().Play();

    }


    void Update()
    {
        
    }
}
