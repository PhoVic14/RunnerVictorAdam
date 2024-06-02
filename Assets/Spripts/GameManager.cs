using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highscoreText;

    int score = 0;
    int highscore = 0;
    public static GameManager inst;

    [SerializeField] PlayerMovement playerMovement;

    [SerializeField] private LeaderBoardController leaderboard;

    private void Awake()
    {
        inst = this;
    }

    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        highscore = PlayerPrefs.GetInt("highscore", 0);
        scoreText.text = "Score: " + score.ToString();
        highscoreText.text = "HighScore: " + highscore.ToString();
    }

    public void IncrementScore()
    {
        score += 1;
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("score", score);
        if (highscore < score)
        {
            PlayerPrefs.SetInt("highscore", score);
            Debug.Log($"New highscore: {score}. Updating leaderboard with username: {PlayerPrefs.GetString("Username")}");
        }

        playerMovement.speed += playerMovement.speedIncreasePerPoint;
    }

    void Update()
    {

    }
}
