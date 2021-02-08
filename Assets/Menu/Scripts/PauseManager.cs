using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseManager : MonoBehaviour
{
    public GameObject pauseScreen;
    public GameObject restartGame;
    public GameObject gameControls;
    public GameObject options;
    public GameObject mainMenu;
    public GameObject pause;

    public void GoToPause() 
    {
        pauseScreen.SetActive(true);
        restartGame.SetActive(false);
        mainMenu.SetActive(false);
    }

    public void ResumeGame()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void GoToRestartLevel()
    {
        restartGame.SetActive(true);
        pauseScreen.SetActive(false);
    }

    public void RestartLevel()
    {
        pauseScreen.SetActive(false);
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("Gameplay");
    }

    public void GoToControls()
    {
        gameControls.SetActive(true);
        pauseScreen.SetActive(false);
    }

    public void GoToOptions()
    {
        options.SetActive(true);
        pauseScreen.SetActive(false);
    }

    public void GoToMainMenu()
    {
        mainMenu.SetActive(true);
        pauseScreen.SetActive(false);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
