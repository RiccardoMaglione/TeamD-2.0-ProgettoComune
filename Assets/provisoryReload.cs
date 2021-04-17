using UnityEngine;
using UnityEngine.SceneManagement;

public class provisoryReload : MonoBehaviour
{
    public void Restart()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void ToGameplay()
    {
        SceneManager.LoadScene(2);
    }

    public void ToBlockout()
    {
        SceneManager.LoadScene(2);
    }
}
