using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ServiceElevator : MonoBehaviour
{
    public GameObject platform;
    public float speed;

    public Vector3 maxHeight;
    public Vector3 minHeight;

    private bool active;
    private bool ascend;
    private int manual;

    private void Start()
    {
        active = false;
        ascend = true;
        manual = 0;
    }

    private void Update()
    {
        switch (manual)
        {
            case 0:
                break;
            case 1:
                ascend = true;
                break;
            case -1:
                ascend = false;
                break;
            default:
                break;
        }

        if (active)
        {
            if (platform.transform.localPosition.y < maxHeight.y && ascend)
            {
                platform.transform.Translate(Vector3.up * speed * Time.deltaTime);
            }
            else if (platform.transform.localPosition.y >= maxHeight.y)
            {
                ascend = false;
            }

            if (platform.transform.localPosition.y > minHeight.y && !ascend)
            {
                platform.transform.Translate(Vector3.down * speed * Time.deltaTime);
            }
            else if (platform.transform.localPosition.y <= maxHeight.y)
            {
                ascend = true;
            }
        }
    }

    private bool HeightCheck()
    {
        return platform.transform.localPosition.y < maxHeight.y && platform.transform.localPosition.y > minHeight.y;
    }

    private void ToggleActive(bool b)
    {
        active = b;
    }

    private void ToggleManual(int i)
    {
        manual = i;
    }
}
