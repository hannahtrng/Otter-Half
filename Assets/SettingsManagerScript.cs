using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;  // For UI components like Button and Slider

public class SettingsManager : MonoBehaviour
{
    public GameObject settingsPanel;      // The Settings Panel (pop-up)
    public Button openSettingsButton;     // The button that opens the settings panel
    public Button quitButton;      // Button to change to another scene
    public Button restartButton;          // Button to restart the game
    public Slider volumeSlider;           // Slider for adjusting the volume
    public bool open;
    private void Start()
    {
        // Make sure the settings panel is initially inactive
        settingsPanel.SetActive(false);
        open = false;

        // Add listeners to buttons
        openSettingsButton.onClick.AddListener(OpenSettingsPanel);
        if (quitButton != null)
        {
            quitButton.onClick.AddListener(ChangeScene);
        }
        else
        {
            Debug.LogWarning("QuitButton is not assigned in the Inspector.");
        }
        if (restartButton != null)
        {
            restartButton.onClick.AddListener(RestartGame);
        }
        else
        {
            Debug.LogWarning("RestartButton is not assigned in the Inspector.");
        }
        volumeSlider.onValueChanged.AddListener(AdjustVolume);

        // Load the saved volume setting (if any)
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 1f); // Default value = 1
    }

    // Open the settings panel
    private void OpenSettingsPanel()
    {
        if (!open)
        {
            settingsPanel.SetActive(true);  // Show the pop-up panel
            open = true;
        }
        else
        {
            settingsPanel.SetActive(false);  // Hide the pop-up panel
            open = false;

        }
    }
    // Change to a specific scene (e.g., "MainMenu")
    private void ChangeScene()
    {
        SceneManager.LoadScene("End Scene");  // Replace "MainMenu" with your desired scene name
    }

    // Restart the current scene
    private void RestartGame()
    {
        // Reload the current scene
        SceneManager.LoadScene("Start Screen");
    }

    // Adjust the volume and save it
    private void AdjustVolume(float value)
    {
        // Set the volume of the game
        AudioListener.volume = value;

        // Save the volume setting so it persists across scenes
        PlayerPrefs.SetFloat("Volume", value);
    }
}
