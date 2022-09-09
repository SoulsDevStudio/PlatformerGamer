using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int score;
    public Text scoreText;

    void Awake()
    {
        instance = this;    
    }

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void GetCoin()
    {
        score++;
        scoreText.text = "x" + score.ToString();
    }
}
