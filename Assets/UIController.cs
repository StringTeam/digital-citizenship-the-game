using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject uiPanel; // Reference to the UI panel game object

    // This method is called when the button is clicked
    public void OnButtonClick()
    {
        uiPanel.SetActive(true); // Set the UI panel to active
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            uiPanel.SetActive(true); // Set the UI panel to active when the Space key is pressed
        }
    }
}   