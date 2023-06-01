using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    private void Update()
    {
        // Check if the Enter key is pressed
        // Check if the "1" key is pressed
if (Input.GetKeyDown(KeyCode.Alpha1) || Input.GetKeyDown(KeyCode.Keypad1))
{
    // Change to the "First_Scene"
    SceneManager.LoadScene("First_Scene");
}
    }
}