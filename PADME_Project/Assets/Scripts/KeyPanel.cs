using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPanel : MonoBehaviour
{
    public GameController gameController;
    public GameObject doors;
    public GameObject twinPanel;
    public bool active;
    public Material lightStrip;
    private bool enabled;
    public int clearanceLevel;

    private Color activeCol = new Color(0, 255, 168, 0);
    private Color deactiveCol = new Color(255, 0, 0, 0);

    private void Start()
    {
        lightStrip.SetColor("_EmissionColor", deactiveCol);
        active = false;
        enabled = false;
        clearanceLevel = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && enabled)
        {
            active = !active;
            lightSwitch();
            ActivateDoor();
            twinPanel.SendMessage("ToggleActive", active);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Controller" && gameController.PlayerHasKeyCard(clearanceLevel))
        {
            enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.name == "Controller" && gameController.PlayerHasKeyCard(clearanceLevel))
        {
            enabled = false;
        }
    }

    private void lightSwitch()
    {
        if(active)
        {
            lightStrip.SetColor("_EmissionColor", activeCol);
        }
        else
        {
            lightStrip.SetColor("_EmissionColor", deactiveCol);
        }
    }

    private void ActivateDoor()
    {
        doors.SendMessage("ToggleActive", active);
    }

    private void ToggleActive(bool b)
    {
        active = b;
    }
}
