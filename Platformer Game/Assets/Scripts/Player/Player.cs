using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D rig;

    bool isAttacking;
    bool isJumping;
    bool doubleJumping;

    float recoveryCount;

    public float radius;
    public float jumpForce;
    public float speed;
    public float recovery;
    
    public int health;

    public Transform pointAttack;
    public Animator anim;
    public LayerMask layer;
    public static Player instance;

    void Awake()
    {

        DontDestroyOnLoad(this);

        if(instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Jump();
        Attack();
    }

    void FixedUpdate()
    {
        Move();   
    }

    void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            isAttacking = true;
            anim.SetInteger("Transition", 3);

            Collider2D hit = Physics2D.OverlapCircle(pointAttack.position, radius,layer);

            if(hit != null)
            {
                if (hit.GetComponent<Slime>())
                {
                    hit.GetComponent<Slime>().OnHit();
                }

                if (hit.GetComponent<Globin>())
                {
                    hit.GetComponent<Globin>().OnHit();
                }
                
            }

            StartCoroutine(OnAttack());
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointAttack.position, radius);
    }

    IEnumerator OnAttack()
    {
        yield return new WaitForSeconds(0.33f);
        isAttacking = false;
    }

    void Move()
    {
        float movement = Input.GetAxis("Horizontal");

        rig.velocity = new Vector2(movement * speed, rig.velocity.y);

        if(movement > 0)
        {
            if (!isJumping && !isAttacking)
            {
                anim.SetInteger("Transition", 1);
            }
            transform.eulerAngles = new Vector2(0,0);
        }

        if(movement < 0)
        {
            if (!isJumping && !isAttacking)
            {
                anim.SetInteger("Transition", 1);
            }
            transform.eulerAngles = new Vector2(0, 180);
        }

        if(movement == 0 && !isJumping && !isAttacking)
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

    public void OnHit()
    {
        recoveryCount += Time.deltaTime;

        if(health >= 1)
        {
            if(recoveryCount >= recovery)
            {
                anim.SetTrigger("Hit");
                health--;

                recoveryCount = 0;
            }
            
        }
        else
        {
            anim.SetTrigger("Death");
        }
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.layer == 3)
        {
            isJumping = false;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 6)
        {
            OnHit();
        }

        if (collision.CompareTag("Coin"))
        {
            collision.GetComponent<Animator>().SetTrigger("Hit");
            GameController.instance.GetCoin();
            Destroy(collision, 0.5f);
        }

        if(collision.gameObject.layer == 7)
        {
            GameController.instance.Level2();
        }

        if(collision.gameObject.layer == 8)
        {
            PlayerSpawn.instance.Spawn();
        }
    }


}
