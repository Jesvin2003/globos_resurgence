using UnityEngine;
using TMPro;

public class CountdownTimer : MonoBehaviour
{
    public TMP_Text countdownText; // TMP text to display the countdown
    public float countdownDuration = 3f; // Duration of the countdown in seconds
    public TimeLimit timeLimitScript; // Reference to the TimeLimit script attached to another GameObject

    private void Start()
    {
        // Start the countdown when the script starts
        StartCountdown();
    }

    private void StartCountdown()
    {
        StartCoroutine(CountdownRoutine());
    }

    private System.Collections.IEnumerator CountdownRoutine()
    {
        // Show "3" for 1 second
        countdownText.text = "3";
        yield return new WaitForSeconds(1f);

        // Show "2" for 1 second
        countdownText.text = "2";
        yield return new WaitForSeconds(1f);

        // Show "1" for 1 second
        countdownText.text = "1";
        yield return new WaitForSeconds(1f);

        // Show an empty string to clear the countdown text
        countdownText.text = "";

        // Start the main timer in the TimeLimit script after the countdown finishes
        timeLimitScript.StartTimer();
    }
}
