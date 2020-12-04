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
        if (gameObject.name == "Crowbar" || gameObject.name == "Crowbar(Clone)")
        {


            anim = GetComponent<Animator>();
        }
        

    }


    void Update()
    {
        rb.isKinematic = true;
        if (Input.GetMouseButtonDown(0) && (gameObject.name == "Crowbar" || gameObject.name == "Crowbar(Clone)"))
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
