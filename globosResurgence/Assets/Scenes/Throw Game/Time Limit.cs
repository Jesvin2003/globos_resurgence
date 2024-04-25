using UnityEngine;
using TMPro;

public class TimeLimit : MonoBehaviour
{
    public float timeLimitInSeconds = 60f; // Time limit in seconds
    private float currentTime; // Current time left
    private bool isTimeUp = false; // Flag to indicate if time is up
    public TMP_Text timerText; // TMP text to display the timer
    private bool timerStarted = false; // Flag to indicate if the timer has started

    private void Start()
    {
        // Initialize the timer
        currentTime = timeLimitInSeconds;
        UpdateTimerDisplay();
    }

    private void Update()
    {
        if (timerStarted && !isTimeUp)
        {
            // Countdown the timer
            currentTime -= Time.deltaTime;

            // Update the timer display
            UpdateTimerDisplay();

            // Check if time is up
            if (currentTime <= 0f)
            {
                currentTime = 0f;
                isTimeUp = true;
                // Call a method or trigger an event when time is up
                TimeUp();
            }
        }
    }

    private void UpdateTimerDisplay()
    {
        // Update the TMP text to display the remaining time
        if (timerText != null)
        {
            timerText.text = "Time: " + Mathf.CeilToInt(currentTime).ToString();
        }
    }

    public void StartTimer()
    {
        // Enable the timer
        timerStarted = true;
    }

    // Method to be called when time is up
    private void TimeUp()
    {
        Debug.Log("Time's up!");
        // Add actions you want to take when the time is up, like ending the game or showing a message
    }
}
