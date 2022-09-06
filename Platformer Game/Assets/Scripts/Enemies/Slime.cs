using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    Rigidbody2D rig;
    Animator anim;

    public int health;

    public float speed;
    public float radius;

    public Transform point;
    public LayerMask layer;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    
    void Update()
    {
        
    }

    void FixedUpdate()
    {
        rig.velocity = new Vector2(speed, rig.velocity.y);
        OnCollision();
    }

    void OnCollision()
    {
        Collider2D hit = Physics2D.OverlapCircle(point.position, radius,layer);

        if(hit != null)
        {
            speed = -speed;

            if(transform.eulerAngles.y == 0)
            {
                transform.eulerAngles = new Vector3(0, 180, 0);
            }
            else
            {
                transform.eulerAngles = new Vector3(0, 0, 0);
            }
        }
    }

    public void OnHit()
    {
        anim.SetTrigger("Hit");
        health--;

        if(health <= 0)
        {
            speed = 0;
            anim.SetTrigger("Death");
            GetComponent<BoxCollider2D>().enabled = false;
            Destroy(gameObject, 1f);
            
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(point.position, radius);
    }
}
