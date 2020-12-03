using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipHandler : MonoBehaviour
{
    public GameObject prefab;
    Rigidbody rb;
    Animator anim;
    

    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();

    }


    void Update()
    {
        rb.constraints = RigidbodyConstraints.FreezePosition;
        rb.isKinematic = true;
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("crowbarAttack");
        }
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        if (Input.GetKey(KeyCode.G))
        {
            Instantiate(prefab, transform.position, transform.rotation);
            Destroy(gameObject);
          
        }
    }
}
