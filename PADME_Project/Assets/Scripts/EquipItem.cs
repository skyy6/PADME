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
    GameController gameController;
    Rigidbody rb;
    bool equipped;

    void Start()
    {
        cam = GameObject.Find("Main Camera").transform;
        player = GameObject.Find("Controller").transform;
        contain = GameObject.Find("Container").transform;
        containLeft = GameObject.Find("ContainerLeft").transform;
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
        

        rb = GetComponent<Rigidbody>();

        equipped = false;
        

    }
    private void OnMouseOver()
    {
        Debug.Log("Looking at" + transform.name);
        float distance = Vector3.Distance(player.position, transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance < 3f && equipped == false)
        {
            if (CompareTag("Crowbar"))
            {
                equipped = true;
                gameController.foundCrowbar = true;
                Instantiate(item, contain.position, contain.rotation, contain);
                Destroy(gameObject);
            }
            else if (CompareTag("Flashlight"))
            {
                equipped = true;
                Instantiate(item, containLeft.position, containLeft.rotation, containLeft);
                Destroy(gameObject);
            }
        }
    }
    void Update()
    {
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
