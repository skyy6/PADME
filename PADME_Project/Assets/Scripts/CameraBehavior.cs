using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehavior : MonoBehaviour
{
    GameObject sparkSystem;
    Transform sparkPos;
    bool destroyed = false;


    void Start()
    {
        sparkSystem = GameObject.Find("Sparks");
        sparkPos = GameObject.Find("Sparks").transform;
        //Physics.IgnoreCollision(sparkPos.GetComponent<Collider>(), transform.GetComponent<Collider>());
    }
    private void OnCollisionEnter(Collision collision)
    {
        //sparkPos.parent = transform;
        sparkSystem.GetComponent<ParticleSystem>().Play();
        destroyed = true;
        //sparkPos = transform;

    }


    void Update()
    {
        //Debug.Log(destroyed);
       /* if (destroyed)
        {
            //sparkPos.parent = transform;
        }*/
    }
}
