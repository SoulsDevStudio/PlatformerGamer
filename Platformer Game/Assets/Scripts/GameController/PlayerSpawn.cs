using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour
{

    private Transform player;

    public static PlayerSpawn instance;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        if(player != null)
        {
            Spawn();
        }
    }

    public void Spawn()
    {
        Vector3 playerPos = transform.position;
        playerPos.z = 0f;

        player.position = playerPos;
    }
}
