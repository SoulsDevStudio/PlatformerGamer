using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;
    bool isJumping;
    bool doubleJumping;

    public float jumpForce;
    public float speed;

    public Animator anim;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
    }

    void FixedUpdate()
    {
        Move();   
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if(movement > 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("Transition", 1);
            }
            transform.eulerAngles = new Vector2(0,0);
        }

        if(movement < 0)
        {
            if (!isJumping)
            {
                anim.SetInteger("Transition", 1);
            }
            transform.eulerAngles = new Vector2(0, 180);
        }

        if(movement == 0 && !isJumping)
        {
            anim.SetInteger("Transition", 0);
        }
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (!isJumping)
            {
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                isJumping = true;
                doubleJumping = true;
                anim.SetInteger("Transition", 2);
            }
            else if (doubleJumping)
            {
                rig.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                doubleJumping = false;
                anim.SetInteger("Transition", 4);
            }
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 3)
        {
            isJumping = false;
        }
    }
}
