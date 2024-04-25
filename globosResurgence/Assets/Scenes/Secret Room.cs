using UnityEngine;
using System.Collections;


public class SecretRoom : MonoBehaviour
{
    public SpriteRenderer spriteRenderer; // Reference to the SpriteRenderer component of the asset to fade
    public float fadeDuration = 1f; // Duration of the fade effect
    private Color originalColor; // Original color of the sprite
    private Color transparentColor; // Transparent color
    private bool isFading = false; // Flag to track if fading is in progress

    private void Start()
    {
        // Initialize originalColor and transparentColor
        originalColor = spriteRenderer.color;
        transparentColor = new Color(originalColor.r, originalColor.g, originalColor.b, 0f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isFading)
        {
            // Start fading out
            StartFade(transparentColor);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isFading)
        {
            // Start fading in
            StartFade(originalColor);
        }
    }

    private void StartFade(Color targetColor)
    {
        // Start fading coroutine
        StartCoroutine(FadeToColor(targetColor));
    }

    private IEnumerator FadeToColor(Color targetColor)
    {
        isFading = true;

        // Calculate the step based on fadeDuration
        float step = 1 / fadeDuration;

        // Loop until the sprite's color reaches the target color
        while (spriteRenderer.color != targetColor)
        {
            // Move towards the target color
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, targetColor, step * Time.deltaTime);
            yield return null;
        }

        isFading = false;
    }
}
