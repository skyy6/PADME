using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIAnimation : MonoBehaviour
{
    public bool ending = false;
    public Animator anim;
    void Start()
    {
        //anim.GetComponent<Animator>();
    }

    
    void Update()
    {
        if (ending)
        {
            anim.Play("FadeOut");
        }
    }

    public void EndingGame(bool b)
    {
        ending = b;
    }
}
