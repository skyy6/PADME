using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public bool keyCardLevel1 = false;
    public bool keyCardLevel2 = false;
    public bool keyCardLevel3 = false;
    public bool foundCrowbar = false;
    public bool playerDetected = false;
    public bool playerVent = false;
    public bool playerEscaped = false;

    public bool PlayerHasKeyCard(int i)
    {
        bool b = false;
        switch (i)
        {
            case 1:
                b = keyCardLevel1;
                break;
            case 2:
                b = keyCardLevel2;
                break;
            case 3:
                b = keyCardLevel3;
                break;
            default:
                break;
        }
        return b;
    }

    public void PlayerFoundKeyCard(int i)
    {
        switch (i)
        {
            case 1:
                keyCardLevel1 = true;
                break;
            case 2:
                keyCardLevel2 = true;
                break;
            case 3:
                keyCardLevel3 = true;
                break;
            default:
                break;
        }
    }
    public void PlayerFoundCrowbar(bool b)
    {
        foundCrowbar = b;
    }

    public void PlayerDetected(bool b)
    {
        playerDetected = b;
    }
    public void PlayerEnterVent(bool b)
    {
        playerVent = b;
    }
    public void PlayerEscape(bool b)
    {
        playerEscaped = b;
    }
    
}
