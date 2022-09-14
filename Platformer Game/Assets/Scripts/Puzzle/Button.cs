using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{

    Animator anim;

    public Animator animDoor;
    public Transform point;

    public float boxX;
    public float boxY;
    public float boxSize;

    void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        BoxHit();
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

    void BoxHit()
    {
        Collider2D hit = Physics2D.OverlapBox(point.position, new Vector2(boxX,boxY),boxSize);

        if(hit != null)
        {
            OnPressed();
        }
        else
        {
            OnExit();
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(point.position, new Vector3(boxX, boxY, 0));
    }


}
