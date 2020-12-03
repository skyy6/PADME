using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipBehavior : MonoBehaviour
{
    Transform cam;
    Transform player;
    Animator anim;
    GameObject pos;
    Rigidbody rb;
    bool equipped;

    void Start()
    {
        cam = GameObject.Find("Main Camera").transform;
        player = GameObject.Find("Controller").transform;
        pos = GameObject.Find("Container");
        rb = GetComponent<Rigidbody>();
        equipped = false;
        anim = GetComponent<Animator>();

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

            //rb.isKinematic = true;
            rb.useGravity = false;
           
            equipped = true;
        }
    }
    void Update()
    {
        rb.useGravity = false;
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;


        if (equipped)
        {
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            //rb.constraints = RigidbodyConstraints.FreezeRotation;
        }
        

        if (Input.GetButton("Fire1"))
        {
            Debug.Log("Slag");
            anim.Play("crowbarAttack");
        }

        if (Input.GetKey(KeyCode.G))
        {
            transform.SetParent(null);
            //rb.isKinematic = false;
            rb.useGravity = true;
            //rb.constraints = RigidbodyConstraints.None;
            equipped = false;
        }
    }
}
