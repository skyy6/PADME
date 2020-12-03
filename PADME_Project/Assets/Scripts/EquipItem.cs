using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipItem : MonoBehaviour
{
    Transform cam;
    Transform player;
    Transform contain;
    GameObject pos;
    public GameObject crow;
    Rigidbody rb;
    bool equipped;

    void Start()
    {
        cam = GameObject.Find("Main Camera").transform;
        player = GameObject.Find("Controller").transform;
        contain = GameObject.Find("Container").transform;
        
        rb = GetComponent<Rigidbody>();
        equipped = false;
        

    }
    private void OnMouseOver()
    {

        float distance = Vector3.Distance(player.position, transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance < 3f)
        {
            equipped = true;
            Instantiate(crow, contain.position, contain.rotation, contain);
            Destroy(gameObject);
        }
    }
    void Update()
    {

    }
}
