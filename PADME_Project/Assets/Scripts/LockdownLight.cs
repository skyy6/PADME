using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockdownLight : MonoBehaviour
{
    public Light light;
    public MeshRenderer meshRend;
    public float rotationSpeed = 0.1f;
    public float duration = 2f;
    private float timeElapsed;
    private Color standardEmission = new Color(0, 0, 0, 0);
    private Color lockdownEmission = new Color(255, 0, 0, 0);
    private float emissionLerp;
    public Material lightMaterial;
    private Material standardMaterial;

    private float maxIntensity;
    public bool lockdown;

    private void Start()
    {
        standardMaterial = new Material(lightMaterial);
        meshRend = GetComponent<MeshRenderer>();
        meshRend.materials[1].SetColor("_EmissionColor", standardEmission);
        maxIntensity = light.intensity;
        light.intensity = 0f;
        lockdown = false;   
    }

    private void Update()
    {
        if(lockdown)
        {
            transform.Rotate(0f, rotationSpeed, 0f);

            if (timeElapsed < (duration / 2))
            {
                light.intensity = Mathf.Lerp(0f, maxIntensity, timeElapsed / (duration / 2));
                meshRend.materials[1].SetColor("_EmissionColor", Color.Lerp(standardEmission, lockdownEmission, timeElapsed / (duration / 2)));
                timeElapsed += Time.deltaTime;
            }
            else if (timeElapsed > (duration / 2))
            {
                light.intensity = Mathf.Lerp(maxIntensity, 0f, timeElapsed / (duration / 2));
                meshRend.materials[1].SetColor("_EmissionColor", Color.Lerp(lockdownEmission, standardEmission, timeElapsed / (duration / 2)));
                timeElapsed += Time.deltaTime;
            }
            if (timeElapsed > duration)
            {
                timeElapsed = 0;
            }
        }
    }

    public void Lockdown(bool b)
    {
        lockdown = b;
        if(!b)
        {
            light.intensity = 0f;
            meshRend.materials[1].SetColor("_EmissionColor", standardEmission);
        }
    }
}
