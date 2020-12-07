using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateDoors : MonoBehaviour
{
    public float turnSpeed;
    bool startRotate;

    void Start()
    {
    }
    private void OnTriggerEnter(Collider other)
    {
        startRotate = true;
        StartCoroutine(RotateTime());
    }
    private void OnTriggerExit(Collider other)
    {
        startRotate = false;
        
    }
    IEnumerator RotateTime()
    {
        float rotationTime = 4.5f;

        while (rotationTime > 0)
        {
            transform.Rotate(Vector3.up, Time.deltaTime * turnSpeed);    
            rotationTime -= Time.deltaTime;   

            yield return null;     
        }

    }

  
    void Update()
    {


    }
}
