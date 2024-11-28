using UnityEngine;
using UnityEngine.SceneManagement;

public class BackButton : MonoBehaviour
{
    // This method is triggered when the Back Button is clicked
    public void OnClick()
    {
        Debug.Log("Back Button Pressed"); // Logs the click event for debugging
        SceneManager.LoadScene("Start Screen");
    }
}
