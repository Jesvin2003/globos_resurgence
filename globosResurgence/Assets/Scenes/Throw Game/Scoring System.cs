using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoringSystem : MonoBehaviour
{
    public TMP_Text scoreText; // Reference to the UI Text element

    private int score = 0; // The current score

    void Start()
    {
        UpdateScoreText(); // Update the score text when the game starts
    }

    public void AddScore(int points)
    {
        score += points; // Add points to the score
        UpdateScoreText(); // Update the score text
    }

    void UpdateScoreText()
    {
        scoreText.text = "Score: " + score.ToString(); // Update the UI Text with the current score
    }
}
