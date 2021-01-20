using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject startingScreen;
    public GameObject settings;
   

    public void GoToStartingScreen()
    {
        startingScreen.SetActive(true);
        settings.SetActive(false);
    }

    public void GoToSettings()
    {
        settings.SetActive(true);
        startingScreen.SetActive(false);           
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
