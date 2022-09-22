using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedSpace : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {


        if (Input.GetKey(KeyCode.Space))
        {
            anim.SetBool("Pressed", true);
        }
        else
        {
            anim.SetBool("Pressed", false);
        }

    }
}
