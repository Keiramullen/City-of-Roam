using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    private Text scoreText;
    private Text highscoreText;

    public float score;
    public float highscore;
    
    [SerializeField]
    public float scoreIncreasePerSecond;
    

    void Start()
    {
        score = 0f;
        highscore = PlayerPrefs.GetInt("Highscore", 0);
        scoreIncreasePerSecond = 10f;
        
    }

    public void AddScore()
    {
        score += scoreIncreasePerSecond * Time.deltaTime;
    }

    void Update()
    {
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "Highscore: " + highscore.ToString();
        AddScore();
        if(score > highscore)
        {
            highscore = score;
            PlayerPrefs.SetInt("Highscore", (int)highscore);
        }
    }
}
