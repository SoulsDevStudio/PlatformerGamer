using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globin : MonoBehaviour
{
    Rigidbody2D rig;
    Animator anim;

    GameObject player;

    public float speed;
    public float maxVision;
    public float stopDistance;
    public float distancePlayer;
    public float health;

    public Transform point;
    
    Vector2 direction;

    public bool spottedPlayer;
    public bool isRight;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        player = GameObject.FindGameObjectWithTag("Player");

        OnPosition();

        if (isRight)
        {
            transform.eulerAngles = new Vector2(0, 0);
            direction = Vector2.right;
        }
        else
        {
            transform.eulerAngles = new Vector2(0, 180);
            direction = Vector2.left;
        }
    }

    void Update()
    {
        OnPosition();
    }

    void OnPosition()
    {
        Vector2 localPosition = player.transform.position - transform.position;
        localPosition = localPosition.normalized;
        distancePlayer = localPosition.x;

        if (distancePlayer >= 0)
        {
            transform.eulerAngles = new Vector2(0, 0);
                direction = Vector2.right;
            isRight = true;
        }
        else
        {
            isRight = false;
            transform.eulerAngles = new Vector2(0, 180);
            direction = Vector2.left;
        }
    }

    void FixedUpdate()
    {
        GetPlayer();

        OnMove();
    }

    void OnMove()
    {
        if (spottedPlayer)
        {
            anim.SetInteger("Transition",1);
            if (isRight)
            {
                transform.eulerAngles = new Vector2(0, 0);
                direction = Vector2.right;
                rig.velocity = new Vector2(speed, rig.velocity.y);
            }
            else
            {
                transform.eulerAngles = new Vector2(0, 180);
                direction = Vector2.left;
                rig.velocity = new Vector2(-speed, rig.velocity.y);
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
            Destroy(gameObject, 1f);
        }
    }

    void GetPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(point.position, direction, maxVision);

        if(hit.collider != null)
        {
            if (hit.transform.CompareTag("Player"))
            {
                spottedPlayer = true;

                float distance = Vector2.Distance(transform.position, hit.transform.position);
                
                if(distance <= stopDistance)
                {
                    spottedPlayer = false;
                    rig.velocity = Vector2.zero;

                    if(hit.transform.GetComponent<Player>().HealthSystem.health >= 0)
                    {
                        anim.SetInteger("Transition", 2);
                        hit.transform.GetComponent<Player>().OnHit();
                    }

                    
                }
            }
            else
            {
                spottedPlayer = false;
                rig.velocity = Vector2.zero;
                anim.SetInteger("Transition", 0);
            }
        }
        else
        {
            spottedPlayer = false;
            rig.velocity = Vector2.zero;
            anim.SetInteger("Transition", 0);
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(point.position, direction * maxVision);
    }
}
