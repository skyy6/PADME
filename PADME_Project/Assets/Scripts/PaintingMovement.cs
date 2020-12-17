using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaintingMovement : MonoBehaviour
{
    public SafeHatchMover mover;
    public Vector3 startPos;
    public Vector3 openPos;
    public bool active;
    public float speed;

    private void Start()
    {
        active = false;
    }

    private void Update()
    {
        if(active)
        {
            if (transform.localPosition.x < openPos.x)
            {
                transform.Translate(Vector3.left * speed * Time.deltaTime);
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.name == "Controller")
        {
            if(Input.GetKeyUp(KeyCode.E))
            {
                Debug.Log("Painting activated");
                active = true;
                StartCoroutine(ActivationDelay());
            }
        }
    }

    IEnumerator ActivationDelay()
    {
        yield return new WaitForSeconds(2f);
        mover.Activate(true);
    }
}
