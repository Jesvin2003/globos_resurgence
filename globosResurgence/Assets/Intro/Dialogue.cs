using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;
    private int index;
    private bool canClick = true; // Flag to control click cooldown

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        // Check for mouse click and if clicking is allowed
        if (Input.GetMouseButtonDown(0) && canClick)
        {
            // Start a coroutine to handle the delay between clicks
            StartCoroutine(ClickCooldown());

            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }
    }

    void StartDialogue()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        // Type each character 1 by 1
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            // Load the next scene when dialogue ends
            LoadNextScene();
        }
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

    void LoadNextScene()
    {
        // Check if there's another scene to load
        if (SceneManager.sceneCountInBuildSettings > SceneManager.GetActiveScene().buildIndex + 1)
        {
            // Load the next scene
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Debug.Log("No more scenes to load.");
        }
    }
}
