using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ClickInteraction : MonoBehaviour
{
    public TMP_Text textDisplay;
    public int valueToShow = 250;

    void Start()
    {
        // Make sure the text display is set to empty initially
        textDisplay.text = "";
    }

    void Update()
    {
        // Check for left mouse click
        if (Input.GetMouseButtonDown(0))
        {
            // Raycast to check if the click happened within the collider
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            
            // If the collider was hit and it's the collider of this object
            if (hit.collider != null && hit.collider.gameObject == gameObject)
            {
                // Display the value
                textDisplay.text = valueToShow.ToString();
            }
        }
    }
}
