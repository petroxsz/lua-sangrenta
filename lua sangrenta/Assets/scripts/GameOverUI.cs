using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverUI : MonoBehaviour
{
    public void RetryGame()
    {
        SceneManager.LoadScene("Level1");
    }

    public void GoToMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void GoToSettings()
    {
        SceneManager.LoadScene("Settings");
    }
}
