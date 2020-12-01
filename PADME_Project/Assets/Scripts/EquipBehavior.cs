using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipBehavior : MonoBehaviour
{
    Transform cam;
    Transform player;
    GameObject pos;
    Rigidbody rb;
    bool equipped = false;

    void Start()
    {
        cam = GameObject.Find("Main Camera").transform;
        player = GameObject.Find("Controller").transform;
        pos = GameObject.Find("Container");
        rb = GetComponent<Rigidbody>();
    }
    private void OnMouseOver()
    {

        float distance = Vector3.Distance(player.position, transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance < 3f)
        {
            transform.SetParent(pos.transform);
            transform.localPosition = Vector3.zero;
            transform.localRotation = Quaternion.Euler(Vector3.zero);
            transform.localScale = Vector3.one;

            rb.isKinematic = true;
            equipped = true;
        }
    }
    void Update()
    {

        if (Input.GetKey(KeyCode.G))
        {
            transform.SetParent(null);
            rb.isKinematic = false;
            equipped = false;
        }
    }
}
