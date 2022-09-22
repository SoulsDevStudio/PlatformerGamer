using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressedD : MonoBehaviour
{
    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {


        if (Input.GetKey(KeyCode.D))
        {
            anim.SetBool("Pressed", true);
        }
        else
        {
            anim.SetBool("Pressed", false);
        }

    }
}
