using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI highScoreText;

    public Transform playerTransform; // Reference to the player's transform

    private float startingXPosition;
    private int score;
    private int highScore;

    void Start()
    {
        // Store the starting x-position of the player
        startingXPosition = playerTransform.position.x;
        score = 0;
        highScore = PlayerPrefs.GetInt("HighScore", 0);
        UpdateScoreText();
        UpdateHighScoreText();
    }

    void Update()
    {
        // Calculate the score based on the x-axis movement
        float distanceCovered = playerTransform.position.x - startingXPosition;
        score = Mathf.FloorToInt(distanceCovered);
        UpdateScoreText();

        // Update the high score if the current score is greater
        if (score > highScore)
        {
            highScore = score;
            UpdateHighScoreText();
            PlayerPrefs.SetInt("HighScore", highScore);
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString();
    }

    void UpdateHighScoreText()
    {
        highScoreText.text = "High Score: " + highScore.ToString();
    }
}
