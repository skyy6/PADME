using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    Transform cam;
    Transform player;
    Transform contain;
    Transform containLeft;
    GameObject pos;
    public GameObject item;
    Rigidbody rb;
    bool equipped;

    void Start()
    {
        cam = GameObject.Find("Main Camera").transform;
        player = GameObject.Find("Controller").transform;
        contain = GameObject.Find("Container").transform;
        containLeft = GameObject.Find("ContainerLeft").transform;

        rb = GetComponent<Rigidbody>();

        equipped = false;
        

    }
    private void OnMouseOver()
    {
        Debug.Log("Looking at" + transform.name);
        float distance = Vector3.Distance(player.position, transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance < 3f && equipped == false)
        {
            if (transform.name == "Crowbar PickUp" || transform.name == "Crowbar PickUp(Clone)")
            {
                equipped = true;
                Instantiate(item, contain.position, contain.rotation, contain);
                Destroy(gameObject);
            }
            else
            {
                equipped = true;
                Instantiate(item, containLeft.position, containLeft.rotation, containLeft);
                Destroy(gameObject);
            }
        }
    }
    void Update()
    {
        Debug.Log(equipped);
        if(contain.childCount > 0)
        {
            equipped = true;
        }
        else
        {
            equipped = false;
        }

    }
}
