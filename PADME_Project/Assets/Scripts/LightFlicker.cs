using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFlicker : MonoBehaviour
{

    public Light light;
    public float minIntensity = 0f;
    public float maxIntensity = 1f;
    public float minFlickerSpeed = 0.1f;
    public float maxFlickerSpeed = 0.5f;

    private bool flicker = true;

    private void Start()
    {
        if(light == null)
        {
            light = GetComponent<Light>();
        }
        StartCoroutine(Flicker());
    }

    void Update()
    {
        
    }

    IEnumerator Flicker()
    {
        yield return new WaitForSecondsRealtime(Random.Range(minFlickerSpeed, maxFlickerSpeed));
        light.intensity = Random.Range(minIntensity, maxIntensity);
        if(flicker)
        {
            StartCoroutine(Flicker());
        }
    }
}
