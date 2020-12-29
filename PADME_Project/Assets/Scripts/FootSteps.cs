using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{
    CharacterController charController;
    public AudioClip metal;
    public AudioClip normal;
    bool onMetal;
    bool onGround;
    bool jumping;
    public float stepRate = 0.5f;
    public float stepCoolDown;
    bool audioStart;
    AudioSource audioSource;

    void Start()
    {
        charController = GetComponent<CharacterController>();
        audioSource = GetComponent<AudioSource>();
    }
    private void VolumePitch()
    {

        stepCoolDown = stepRate;
    }
    private void JumpCheck()
    {
        if (Physics.Raycast(transform.position, Vector3.down, 0.5f))
        {
            jumping = false;
        }
        else
        {
            jumping = true;
        }
    }
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {

        if (hit.transform.tag == "Metal")
        {
            Debug.Log("Metal");
            onMetal = true;
        }
        else
        {
            onMetal = false;
        }
        if (hit.transform.tag == "Ground")
        {
            onGround = true;
        }
        else
        {
            onGround = false;
        }
    }

    void audioConditions()
    {
       if ((Input.GetAxis("Horizontal") != 0f || Input.GetAxis("Vertical") != 0f) && stepCoolDown < 0f && jumping == false)
        {
            audioStart = true;
        }
        else
        {
            audioStart = false;
        }
    }

    void Update()
    {
        JumpCheck();

        stepCoolDown -= Time.deltaTime;

        audioConditions();
        if (audioStart == true && onGround == true)
        {
            VolumePitch();
            audioSource.pitch = 1f + Random.Range(-0.2f, 0.2f);
            audioSource.PlayOneShot(normal, 0.9f);
        }
        if (audioStart == true && onMetal == true)
        {
            VolumePitch();
            audioSource.pitch = 1f + Random.Range(-0.05f, 0.05f);
            audioSource.PlayOneShot(metal, 0.9f);
        }
    }
}
