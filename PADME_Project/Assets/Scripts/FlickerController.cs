using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlickerController : MonoBehaviour
{
    public GameObject pointLights;
    private GameObject[] lights;
    private GameObject[] lockdownLights;
    public List<GameObject> flickering = new List<GameObject>();

    public int flickerNumber = 5;
    public float minInterval = 1f;
    public float maxInterval = 3f;

    private GameObject current;

    private bool lockdown = false;

    private void Start()
    {
        lights = GameObject.FindGameObjectsWithTag("FlickerLight");
        lockdownLights = GameObject.FindGameObjectsWithTag("LockdownLight");
        StartCoroutine(RandomFlicker());
    }

    IEnumerator RandomFlicker()
    {
        while(!lockdown)
        {
            for (int i = 0; i < flickerNumber; i++)
            {
                current = lights[Random.Range(0, lights.Length)];
                flickering.Add(current);
                current.SendMessage("StartFlicker");
            }
            yield return new WaitForSecondsRealtime(Random.Range(minInterval, maxInterval));
            foreach (GameObject g in flickering)
            {
                g.SendMessage("StopFlicker");
            }
            flickering.Clear();
        }           
    }

    public void Lockdown(bool b)
    {
        lockdown = b;
        pointLights.SetActive(!b);
        foreach(GameObject g in lights)
        {
            g.SendMessage("Lockdown", b);
        }
        foreach(GameObject g in lockdownLights)
        {
            g.SendMessage("Lockdown", b);
        }
    }
}
