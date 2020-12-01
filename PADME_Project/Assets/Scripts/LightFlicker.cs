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
        float factor = Random.Range(minIntensity, maxIntensity);
        yield return new WaitForSecondsRealtime(Random.Range(minFlickerSpeed, maxFlickerSpeed));
        light.intensity = factor;
        lightTubes.GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(factor, factor, factor, factor));
        if (flicker)
        {
            StartCoroutine(Flicker());
        }
    }

    GameObject GetChildWithName(GameObject obj, string name)
    {
        Transform trans = obj.transform;
        Transform childTrans = trans.Find(name);
        if (childTrans != null)
        {
            return childTrans.gameObject;
        }
        else
        {
            return null;
        }
    }
}
