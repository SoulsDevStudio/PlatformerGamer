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
    public GameObject gameOver;

    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else if(instance != this)
        {
            Destroy(instance.gameObject);
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        PlayerPrefs.DeleteKey("Score");

        if (PlayerPrefs.GetInt("Score") > 0)
        {
            score = PlayerPrefs.GetInt("Score");
            scoreText.text = "x" + score.ToString();
        }

        
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

    public void ShowGameOver()
    {
        gameOver.SetActive(true);
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
