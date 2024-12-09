using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public GameObject otter;
    // Restart the current game
    public void RestartGame()
    {
        if (otter != null)
        {
            otter.GetComponent<OtterPositionManager>().ResetPosition();
        }
        if (SceneManager.GetActiveScene().name != "Credits")
            SettingsManager.Instance.hasWonFight = false;
        SharkMovement.ResetAllSharkTriggers();
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
        SceneManager.LoadScene("Game Over (Lose)"); // Replace with your game scene name
    }

}
