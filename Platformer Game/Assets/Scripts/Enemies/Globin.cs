using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globin : MonoBehaviour
{
    Rigidbody2D rig;

    public float speed;
    public float maxVision;
    public float stopDistance;

    public Transform point;
    
    Vector2 direction;

    public bool spottedPlayer;
    public bool isRight;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();

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

    void Update()
    {
        
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

                    hit.transform.GetComponent<Player>().OnHit();
                }
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(point.position, direction * maxVision);
    }
}