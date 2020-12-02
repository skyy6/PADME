using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVisibilty : MonoBehaviour
{

    Renderer renderer;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
    }

    private void OnBecameVisible()
    {
        Debug.Log("Player is visible");
    }

    private void OnBecameInvisible()
    {
        Debug.Log("Player is invisible");
    }

    private void Update()
    {
        if(renderer.isVisible)
        {
            Debug.Log("Visible");
        }
    }
}
