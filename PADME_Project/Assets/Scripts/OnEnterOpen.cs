using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnEnterOpen : MonoBehaviour
{
    public GameObject obj;

    void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.name == "Player")
        {
            obj.SendMessage("openObject");
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            obj.SendMessage("openObject");
        }
    }
}
