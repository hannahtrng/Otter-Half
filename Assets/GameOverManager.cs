using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    // Restart the current game
    public void RestartGame()
    {
        SceneManager.LoadScene("Start Screen"); // Replace with your game scene name
    }

    public void Game()
    {
        SceneManager.LoadScene("Cave"); // Replace with your game scene name
    }

    public void Credits()
    {
        SceneManager.LoadScene("Credits"); // Replace with your game scene name
    }

    // Quit the game
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit(); // Only works in a built application
    }
}
