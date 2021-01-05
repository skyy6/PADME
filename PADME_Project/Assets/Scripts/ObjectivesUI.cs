using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectivesUI : MonoBehaviour
{
    bool clicked;
    public GameObject panel;
    public GameController gameController;
    public Text clearanceText;
    public Text crowbarText;
    public Text officeText;
    public Text escapeText;


    void Start()
    {

    }
   private void CheckForProgress()
    {
        if (gameController.keyCardLevel1 == true)
        {
            clearanceText.color = Color.green;
        }
        if(gameController.foundCrowbar == true)
        {
            crowbarText.color = Color.green;
        }
        if(gameController.playerVent == true)
        {
            officeText.color = Color.green;
        }
        if(gameController.playerEscaped == true)
        {
            escapeText.color = Color.green;
        }
    }
    private void ToggleObjectives()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            if (!clicked)
                clicked = true;
            else
                clicked = false;
        }
        if (clicked)
        {
            panel.SetActive(false);

        }
        if (!clicked)
        {

            panel.SetActive(true);
        }

    }

    void Update()
    {

        CheckForProgress();
        ToggleObjectives();


    }

    
}

