using UnityEngine;
using System.Collections;

public class ImageSwitcherWithMusic : MonoBehaviour
{
    public GameObject[] images; // Array to hold your image GameObjects
    public AudioClip[] musicClips; // Array to hold your music clips
    private int currentIndex = 0;
    private AudioSource audioSource;
    private bool canClick = true; // Flag to control click cooldown

    void Start()
    {
        // Show the first image, hide the others
        ShowCurrentImage();

        // Get the AudioSource component attached to this GameObject
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        // Check for mouse click and if clicking is allowed
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            // Start a coroutine to handle the delay between clicks
            StartCoroutine(ClickCooldown());

            // Hide the current image
            images[currentIndex].SetActive(false);
            
            // Move to the next image
            currentIndex = (currentIndex + 1) % images.Length;
            
            // Show the next image
            ShowCurrentImage();

            // Check if we're at the 5th index
            if (currentIndex == 4) // Adjust the index to match your desired position
            {
                // Cut the current music
                audioSource.Stop();
            }
            else if (currentIndex == 7) // Adjust the index to match your desired position
            {
                // Play a new song
                // Check if there's a new music clip assigned
                if (musicClips.Length > 0)
                {
                    // Stop any currently playing music
                    audioSource.Stop();
                    // Play the new music clip
                    audioSource.clip = musicClips[Random.Range(0, musicClips.Length)];
                    audioSource.Play();
                }
            }
        }
    }

    void ShowCurrentImage()
    {
        // Show the image at the current index
        images[currentIndex].SetActive(true);
    }

    IEnumerator ClickCooldown()
    {
        // Disable clicking
        canClick = false;

        // Wait for 1 second
        yield return new WaitForSeconds(1f);

        // Enable clicking
        canClick = true;
    }
}
