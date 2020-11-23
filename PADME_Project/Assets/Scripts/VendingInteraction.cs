using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VendingInteraction : MonoBehaviour
{
    public GameObject can1;
    public GameObject can2;
    public GameObject can3;
    public GameObject can4;
    public GameObject can5;
    public GameObject can6;
    public GameObject can7;
    public GameObject can8;
    public GameObject can9;
    public GameObject can10;
    public GameObject can11;
    public GameObject can12;

    Transform player;
    int canRNG;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Controller").transform;
    }
    private void OnMouseOver()
    {
        float distance = Vector3.Distance(player.position, transform.position);
        if (Input.GetKeyDown(KeyCode.E) && distance < 3f)
        {
            Debug.Log("Tryckt");
            canRNG = Random.Range(1, 13);
            //Instantiate(can+canRNG, )

            switch (canRNG)
            {
                case 1:
                    Instantiate(can1, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.8f, transform.position.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                    break;
                case 2:
                    Instantiate(can2, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.8f, transform.position.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                    break;
                case 3:
                    Instantiate(can3, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.8f, transform.position.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                    break;
                case 4:
                    Instantiate(can4, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.8f, transform.position.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                    break;
                case 5:
                    Instantiate(can5, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.8f, transform.position.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                    break;
                case 6:
                    Instantiate(can6, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.8f, transform.position.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                    break;
                case 7:
                    Instantiate(can7, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.8f, transform.position.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                    break;
                case 8:
                    Instantiate(can8, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.8f, transform.position.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                    break;
                case 9:
                    Instantiate(can9, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.8f, transform.position.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                    break;
                case 10:
                    Instantiate(can10, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.8f, transform.position.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                    break;
                case 11:
                    Instantiate(can11, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.8f, transform.position.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                    break;
                case 12:
                    Instantiate(can12, new Vector3(transform.position.x + 0.5f, transform.position.y - 0.8f, transform.position.z), Quaternion.Euler(new Vector3(90, 0, 0)));
                    break;

            }
        }


    }

    // Update is called once per frame
    void Update()
    {


    }
}
