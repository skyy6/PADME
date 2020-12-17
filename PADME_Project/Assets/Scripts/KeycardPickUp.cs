using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeycardPickUp : MonoBehaviour
{
    public GameController gameController;
    Transform player;
    public int clearanceLevel;

    private void Start()
    {
        player = GameObject.Find("Controller").transform;
        clearanceLevel = 1;
    }

    private void OnMouseOver()
    {
        Debug.Log("Looking at" + transform.name);
        float distance = Vector3.Distance(player.position, transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance < 4f)
        {
            gameController.PlayerFoundKeyCard(clearanceLevel);
            Destroy(gameObject);
        }
    }
}
