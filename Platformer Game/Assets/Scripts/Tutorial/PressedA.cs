using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedA : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {


        if (Input.GetKey(KeyCode.A))
        {
            anim.SetBool("Pressed", true);
        }
        else
        {
            anim.SetBool("Pressed", false);
        }

    }
}
