using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VentObjective : MonoBehaviour
{
    GameController gameController;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gameController.playerVent = true;
        }
    }

    void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }

}
