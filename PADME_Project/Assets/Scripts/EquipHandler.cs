using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipHandler : MonoBehaviour
{
    public GameObject prefab;
    Rigidbody rb;
    Animator anim;
    int animNr = 0;
    MeshCollider crowCollider;


    void Start()
    {
        
        rb = GetComponent<Rigidbody>();
        crowCollider = gameObject.GetComponent<MeshCollider>();
        if (gameObject.name == "Crowbar" || gameObject.name == "Crowbar(Clone)")
        {


            anim = GetComponent<Animator>();
        }
        

    }
    void onCrowbarEquipped()
    {
        if (Input.GetMouseButtonDown(0))
        {
            anim.Play("crowbarAttack");
        }
        if (anim.GetCurrentAnimatorStateInfo(0).IsName("crowbarAttack"))
        {
            crowCollider.enabled = true;
        }
    }


    void Update()
    {
        crowCollider.enabled = false;
        rb.isKinematic = true;
        if(gameObject.name == "Crowbar" || gameObject.name == "Crowbar(Clone)")
            {
            onCrowbarEquipped();
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
