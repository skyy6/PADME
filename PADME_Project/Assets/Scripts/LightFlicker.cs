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
    public GameObject lightTubes;
    private Color standardEmission = new Color(255, 255, 255, 255);
    private Color lockdownEmission = new Color(0, 0, 0, 0);
    private Material material;

    public float intensityFactor = 0.01f;

    private void Start()
    {
        if(light == null)
        {
            light = GetComponent<Light>();
        }
        material = new Material(GetComponent<Renderer>().material);
        lightTubes.GetComponent<Renderer>().material = material;
    }

    void Update()
    {

    }

    public void StartFlicker()
    {
        StartCoroutine(Flicker());
    }

    IEnumerator Flicker()
    {
        while(true)
        {
            float factor = Random.Range(minIntensity, maxIntensity);
            yield return new WaitForSecondsRealtime(Random.Range(minFlickerSpeed, maxFlickerSpeed));
            light.intensity = factor;
            material.SetColor("_EmissionColor", new Color(factor, factor, factor, factor));
        }
    }

    public void StopFlicker()
    {
        StopAllCoroutines();
        material.SetColor("_EmissionColor", standardEmission);
    }

    public void Lockdown(bool b)
    {
        if(b)
        {
            StopFlicker();
            light.intensity = 0f;
            material.SetColor("_EmissionColor", lockdownEmission);
        }
        else
        {
            light.intensity = maxIntensity;
            material.SetColor("_EmissionColor", standardEmission);
        }        
    }
}
