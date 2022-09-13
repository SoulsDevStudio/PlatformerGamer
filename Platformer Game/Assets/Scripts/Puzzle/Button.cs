using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    Animator anim;

    public Animator animDoor;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void OnPressed()
    {
        anim.SetBool("isPressed", true);
        animDoor.SetBool("Opening", true);
    }

    void OnExit()
    {
        anim.SetBool("isPressed", false);
        animDoor.SetBool("Opening", false);
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("CubeStone"))
        {
            OnPressed();
        }    
    }

    void OnCollisionExit2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Player") || coll.gameObject.CompareTag("CubeStone"))
        {
            OnExit();
        }
    }


}
