using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneDoor : MonoBehaviour
{
    public GameObject[] enemys;

    Animator anim;

    void Start()
    {
        anim = GetComponent<Animator>();
        enemys = GameObject.FindGameObjectsWithTag("Enemy");

    }

    void Update()
    {
        enemys = GameObject.FindGameObjectsWithTag("Enemy");
        PuzzleEnemy();
    }
    
    void PuzzleEnemy()
    {
        if(enemys.Length <= 0)
        {
            anim.SetTrigger("Opening");
        }
    }
}
