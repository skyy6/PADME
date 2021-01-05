using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndingBehavior : MonoBehaviour
{
    public CharacterController playerController;
    public GameObject levelChanger;
    GameController gameController;

     void Start()
    {
        gameController = GameObject.Find("GameController").GetComponent<GameController>();
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Controller")
        {
            playerController.SendMessage("ToggleTyping", true);
            gameController.playerEscaped = true;
            levelChanger.SendMessage("EndingGame", true);

        }
    }

    void Update()
    {
        
    }
}
