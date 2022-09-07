using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Globin : MonoBehaviour
{
    Rigidbody2D rig;

    public float speed;
    public float maxVision;

    public Transform point;

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    void FixedUpdate()
    {
        GetPlayer();    
    }

    void GetPlayer()
    {
        RaycastHit2D hit = Physics2D.Raycast(point.position, Vector2.right, maxVision);

        if(hit.collider != null)
        {
            if (hit.transform.CompareTag("Player"))
            {
                Debug.Log("To vendo o Inimigo");
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawRay(point.position, Vector2.right * maxVision);
    }
}
