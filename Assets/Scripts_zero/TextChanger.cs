using UnityEngine;
using UnityEngine.UI;

public class TextChanger : MonoBehaviour
{
    public Text textField;

    private void Start()
    {
        // Find the Text component attached to the UI Text object
        textField = GetComponent<Text>();
    }

    private void Update()
    {
        // Check if the Enter key is pressed
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            // Change the text content
            textField.text = "완전 폐허군";
        }
    }
}

