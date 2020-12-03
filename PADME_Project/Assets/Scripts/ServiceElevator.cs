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
    private bool manual;

    private void Start()
    {
        active = true;
        ascend = true;
        manual = false;
    }

    private void Update()
    {
        if (active && !manual)
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

    private void ToggleActive(bool b)
    {
        active = b;
    }
}
