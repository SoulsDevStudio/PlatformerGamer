using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    public static GameController instance;

    public int score;
    public Text scoreText;

    void Awake()
    {
        instance = this;
        if(PlayerPrefs.GetInt("Score") > 0)
        {
            score = PlayerPrefs.GetInt("Score");
            scoreText.text = "x" + score.ToString();
        }
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

        PlayerPrefs.SetInt("Score", score);
    }

    public void Level2()
    {
        SceneManager.LoadScene(1);
    }
}
