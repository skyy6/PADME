using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazyStairs : MonoBehaviour
{
    public GameObject boxSmall;
    public GameObject boxMedium;
    private Quaternion rotate;

    public Vector3 spawnPos1;
    public Vector3 spawnPos2;
    public Vector3 spawnPos3;
    public Vector3 spawnPos4;
    public Vector3 spawnPos5;
    public Vector3 spawnPos6;
    public Vector3 spawnPos7;

    private void Start()
    {
        Debug.Log("För att slippa bygga trappa själv; tryck 'L'");
        rotate = Quaternion.Euler(0, 90, 0);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.L))
        {
            Instantiate(boxMedium, spawnPos1, rotate);
            Instantiate(boxMedium, spawnPos2, rotate);
            Instantiate(boxMedium, spawnPos3, rotate);
            Instantiate(boxSmall, spawnPos4, rotate);
            Instantiate(boxMedium, spawnPos5, rotate);
            Instantiate(boxMedium, spawnPos6, rotate);
            Instantiate(boxSmall, spawnPos7, rotate);
        }
    }
}
