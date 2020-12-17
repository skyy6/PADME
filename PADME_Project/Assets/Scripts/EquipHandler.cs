using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipHandler : MonoBehaviour
{
    public Light light;
    public GameObject prefab;
    Rigidbody rb;
    Animator anim;
    int animNr = 0;
    MeshCollider crowCollider;
    private GameObject itemEquipped;


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

    void OnFlashlightEquipped()
    {
        if (Input.GetMouseButtonDown(0) && light != null)
        {
            light.enabled = !light.enabled;
        }
    }

    void Update()
    {
        crowCollider.enabled = false;
        rb.isKinematic = true;
        //if(gameObject.name == "Crowbar" || gameObject.name == "Crowbar(Clone)")
        if (CompareTag("Crowbar"))
        {
            onCrowbarEquipped();
        }
        if (CompareTag("Flashlight"))
        {
            OnFlashlightEquipped();
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
